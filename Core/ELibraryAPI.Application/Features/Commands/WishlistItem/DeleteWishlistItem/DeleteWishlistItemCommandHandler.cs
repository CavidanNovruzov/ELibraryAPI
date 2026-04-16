using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.WishlistItem.DeleteWishlistItem;

public sealed class DeleteWishlistItemCommandHandler : IRequestHandler<DeleteWishlistItemCommandRequest, Result>
{
    public Task<Result> Handle(DeleteWishlistItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
