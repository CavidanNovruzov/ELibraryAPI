using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.UpdateInventoryMovement;

public sealed class UpdateInventoryMovementCommandHandler : IRequestHandler<UpdateInventoryMovementCommandRequest, Result<UpdateInventoryMovementCommandResponse>>
{
    public Task<Result<UpdateInventoryMovementCommandResponse>> Handle(UpdateInventoryMovementCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
