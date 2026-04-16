using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Wishlist.CreateWishlist;

public sealed class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommandRequest, Result<CreateWishlistCommandResponse>>
{
    public Task<Result<CreateWishlistCommandResponse>> Handle(CreateWishlistCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
