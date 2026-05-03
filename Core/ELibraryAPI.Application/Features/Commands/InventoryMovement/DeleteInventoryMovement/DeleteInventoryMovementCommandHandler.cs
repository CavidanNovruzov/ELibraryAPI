using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork; 
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.DeleteInventoryMovement;

public sealed class DeleteInventoryMovementCommandHandler : IRequestHandler<DeleteInventoryMovementCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryMovementCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryMovementCommandRequest request, CancellationToken ct)
    {
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();

        var isRemoved = await writeRepo.RemoveAsync(request.Id, ct);

        if (!isRemoved)
        {
            return Result.Failure("Inventory movement record not found.");
        }

        var result = await _unitOfWork.SaveAsync(ct);

        return result > 0
            ? Result.Success("Inventory movement record deleted successfully.")
            : Result.Failure("An error occurred while deleting the record.");
    }
}