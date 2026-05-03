using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.DeleteOrderItem;

public sealed record DeleteOrderItemCommandRequest(Guid Id) : IRequest<Result>;
