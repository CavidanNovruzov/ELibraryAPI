using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Wishlist.UpdateWishlist;

public sealed record UpdateWishlistCommandRequest(
    Guid Id,
    Guid UserId
) : IRequest<Result<UpdateWishlistCommandResponse>>;
