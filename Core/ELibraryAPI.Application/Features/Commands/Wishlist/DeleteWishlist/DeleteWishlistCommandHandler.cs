using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Wishlist.DeleteWishlist;

public sealed class DeleteWishlistCommandHandler : IRequestHandler<DeleteWishlistCommandRequest, Result>
{
    public Task<Result> Handle(DeleteWishlistCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
