using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.DeleteInventoryMovement;

public sealed record DeleteInventoryMovementCommandRequest(Guid Id) : IRequest<Result>;
