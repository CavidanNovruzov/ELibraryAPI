using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.WishlistItem.CreateWishlistItem;

public sealed class CreateWishlistItemCommandHandler : IRequestHandler<CreateWishlistItemCommandRequest, Result<CreateWishlistItemCommandResponse>>
{
    public Task<Result<CreateWishlistItemCommandResponse>> Handle(CreateWishlistItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
