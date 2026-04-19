using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

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
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.OrderItem, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.OrderItem, Guid>();

        var orderItem = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (orderItem == null)
        {
            return Result.Failure("Order item not found.");
        }

        orderItem.IsDeleted = true;
        writeRepository.Update(orderItem);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Order item removed successfully.");
    }
}