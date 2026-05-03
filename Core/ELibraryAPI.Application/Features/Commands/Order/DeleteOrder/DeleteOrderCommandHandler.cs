using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Commands.Order.DeleteOrder;

public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOrderCommandRequest request, CancellationToken ct)
    {
        var orderWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Order, Guid>();
        var statusReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.OrderStatus, Guid>();

        var order = await _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>().GetAll(tracking: true, ct: ct)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == request.Id && !o.IsDeleted, ct);

        if (order == null) return Result.Failure("Order not found.");

        var canceledStatus = await statusReadRepo.GetSingleAsync(x => x.Name == "Canceled", tracking: false);

        foreach (var item in order.OrderItems)
        {
            if (item.Product != null)
                item.Product.TotalStockCount += item.Quantity;
        }

        if (canceledStatus != null)
            order.OrderStatusId = canceledStatus.Id;

        orderWriteRepo.Remove(order); 

        await _unitOfWork.SaveAsync(ct);
        return Result.Success("Order canceled and stocks restored.");
    }
}