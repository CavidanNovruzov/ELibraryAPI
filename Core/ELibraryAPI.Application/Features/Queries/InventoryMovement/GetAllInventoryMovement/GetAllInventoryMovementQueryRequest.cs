using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.InventoryMovement.GetAllInventoryMovement;

public sealed record GetAllInventoryMovementQueryRequest : IRequest<Result<GetAllInventoryMovementQueryResponse>>;
