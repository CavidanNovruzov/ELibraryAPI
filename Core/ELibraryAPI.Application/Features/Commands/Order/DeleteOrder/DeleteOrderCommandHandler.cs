using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

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
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Order, Guid>();

        var order = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (order == null)
        {
            return Result.Failure("Order not found.");
        }

        order.IsDeleted = true;
        writeRepo.Update(order);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Order deleted successfully.");
    }
}