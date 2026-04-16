using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Wishlist.UpdateWishlist;

public sealed class UpdateWishlistCommandHandler : IRequestHandler<UpdateWishlistCommandRequest, Result<UpdateWishlistCommandResponse>>
{
    public Task<Result<UpdateWishlistCommandResponse>> Handle(UpdateWishlistCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
