using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.UpdateInventoryMovement;

public sealed record UpdateInventoryMovementCommandRequest(
    Guid Id,
    Guid FromBranchId,
    Guid ProductId,
    int Quantity,
    Guid ToBranchId,
    string Type
) : IRequest<Result<UpdateInventoryMovementCommandResponse>>;
