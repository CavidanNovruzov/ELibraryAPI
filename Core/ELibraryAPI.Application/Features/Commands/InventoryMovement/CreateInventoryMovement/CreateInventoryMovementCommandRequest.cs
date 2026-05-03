using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.CreateInventoryMovement;

public sealed record CreateInventoryMovementCommandRequest(
    Guid FromBranchId,
    Guid ProductId,
    int Quantity,
    Guid ToBranchId,
    string Type
) : IRequest<Result<CreateInventoryMovementCommandResponse>>;
