using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.UpdateBasket;

public sealed record UpdateBasketCommandRequest(
    Guid Id,
    decimal TotalPrice,
    Guid UserId
) : IRequest<Result<UpdateBasketCommandResponse>>;
