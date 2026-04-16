using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.WishlistItem.UpdateWishlistItem;

public sealed class UpdateWishlistItemCommandHandler : IRequestHandler<UpdateWishlistItemCommandRequest, Result<UpdateWishlistItemCommandResponse>>
{
    public Task<Result<UpdateWishlistItemCommandResponse>> Handle(UpdateWishlistItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
