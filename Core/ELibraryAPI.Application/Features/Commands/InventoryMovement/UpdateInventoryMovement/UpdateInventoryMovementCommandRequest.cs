using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.UpdateInventoryMovement;

public sealed record UpdateInventoryMovementCommandRequest(
    Guid Id,
    string Type,
    string Status 
) : IRequest<Result<UpdateInventoryMovementCommandResponse>>;
