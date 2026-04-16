using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.DeleteInventoryMovement;

public sealed class DeleteInventoryMovementCommandHandler : IRequestHandler<DeleteInventoryMovementCommandRequest, Result>
{
    public Task<Result> Handle(DeleteInventoryMovementCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
