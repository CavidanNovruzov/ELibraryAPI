using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.WishlistItem.GetAllWishlistItem;

public sealed class GetAllWishlistItemQueryHandler : IRequestHandler<GetAllWishlistItemQueryRequest, Result<GetAllWishlistItemQueryResponse>>
{
    public Task<Result<GetAllWishlistItemQueryResponse>> Handle(GetAllWishlistItemQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
