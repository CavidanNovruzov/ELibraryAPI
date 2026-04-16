using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.UpdateOrderItem;

public sealed record UpdateOrderItemCommandRequest(
    Guid Id,
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Result<UpdateOrderItemCommandResponse>>;
