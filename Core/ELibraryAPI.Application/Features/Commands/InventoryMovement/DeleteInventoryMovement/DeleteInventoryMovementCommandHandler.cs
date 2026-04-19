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
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();

        var movement = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (movement == null)
        {
            return Result.Failure("Inventory movement not found.");
        }

        movement.IsDeleted = true;
        writeRepo.Update(movement);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Inventory movement record deleted successfully.");
    }
}