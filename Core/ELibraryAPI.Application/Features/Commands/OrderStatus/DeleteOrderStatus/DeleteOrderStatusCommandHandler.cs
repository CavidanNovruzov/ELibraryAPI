using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderStatus.DeleteOrderStatus;

public sealed class DeleteOrderStatusCommandHandler : IRequestHandler<DeleteOrderStatusCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOrderStatusCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.OrderStatus, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.OrderStatus, Guid>();

        var orderStatus = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (orderStatus == null)
        {
            return Result.Failure("Order status not found.");
        }

        orderStatus.IsDeleted = true;
        writeRepository.Update(orderStatus);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Order status deleted successfully.");
    }
}