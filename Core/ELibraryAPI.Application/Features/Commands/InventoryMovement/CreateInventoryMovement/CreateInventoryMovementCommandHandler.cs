using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.CreateInventoryMovement;

public sealed class CreateInventoryMovementCommandHandler : IRequestHandler<CreateInventoryMovementCommandRequest, Result<CreateInventoryMovementCommandResponse>>
{
    public Task<Result<CreateInventoryMovementCommandResponse>> Handle(CreateInventoryMovementCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
