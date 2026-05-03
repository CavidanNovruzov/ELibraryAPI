using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.DeleteOrderItem;

public sealed class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOrderItemCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.OrderItem, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.OrderItem, Guid>();

        var orderItem = await readRepo.GetAll(tracking: true, ct: ct)
            .Include(oi => oi.Product)
            .FirstOrDefaultAsync(oi => oi.Id == request.Id, ct);

        if (orderItem == null)
            return Result.Failure("Order item not found.");

        if (orderItem.Product != null)
        {
            orderItem.Product.TotalStockCount += orderItem.Quantity;
        }

        writeRepo.Remove(orderItem);

        var result = await _unitOfWork.SaveAsync(ct);

        return result > 0
            ? Result.Success("Item removed from order and stock restored.")
            : Result.Failure("An error occurred while deleting the item.");
    }
}