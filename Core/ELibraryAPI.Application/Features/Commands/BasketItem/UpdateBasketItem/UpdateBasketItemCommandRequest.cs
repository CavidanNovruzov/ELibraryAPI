using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.UpdateBasketItem;

public sealed record UpdateBasketItemCommandRequest(
    Guid Id,
    Guid BasketId,
    Guid ProductId,
    int Quantity
) : IRequest<Result<UpdateBasketItemCommandResponse>>;
