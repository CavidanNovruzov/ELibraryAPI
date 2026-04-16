using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.CreateOrderItem;

public sealed record CreateOrderItemCommandRequest(
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Result<CreateOrderItemCommandResponse>>;
