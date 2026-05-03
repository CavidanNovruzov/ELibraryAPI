using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.WishlistItem.MoveToBasket;

public sealed record MoveToBasketCommandRequest(Guid Id, Guid BasketId) : IRequest<Result<MoveToBasketCommandResponse>>;