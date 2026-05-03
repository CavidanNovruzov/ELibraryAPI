using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Order.CreateOrder;

public sealed record CreateOrderCommandRequest(
    string OrderNote,
    string OrderNumber,
    Guid OrderStatusId,
    Guid PaymentMethodId,
    Guid ShippingMethodId,
    decimal TotalAmount,
    Guid UserId
) : IRequest<Result<CreateOrderCommandResponse>>;
