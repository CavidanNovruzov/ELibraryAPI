using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.UpdateInventoryMovement;

public sealed class UpdateInventoryMovementCommandHandler : IRequestHandler<UpdateInventoryMovementCommandRequest, Result<UpdateInventoryMovementCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateInventoryMovementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateInventoryMovementCommandResponse>> Handle(UpdateInventoryMovementCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();

        var movement = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (movement == null)
        {
            return Result<UpdateInventoryMovementCommandResponse>.Failure("Inventory movement record not found.");
        }

        movement.Type = request.Type;
        movement.Status = request.Status;

        writeRepo.Update(movement);
        var result = await _unitOfWork.SaveAsync(ct);

        if (result > 0)
        {
            return Result<UpdateInventoryMovementCommandResponse>.Success(
                new UpdateInventoryMovementCommandResponse(movement.Id),
                "Movement record updated successfully (metadata only).");
        }

        return Result<UpdateInventoryMovementCommandResponse>.Failure("No changes were applied.");
    }
}