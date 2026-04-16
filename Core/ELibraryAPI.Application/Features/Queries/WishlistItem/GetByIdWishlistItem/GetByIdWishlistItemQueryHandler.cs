using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.WishlistItem.GetByIdWishlistItem;

public sealed class GetByIdWishlistItemQueryHandler : IRequestHandler<GetByIdWishlistItemQueryRequest, Result<GetByIdWishlistItemQueryResponse>>
{
    public Task<Result<GetByIdWishlistItemQueryResponse>> Handle(GetByIdWishlistItemQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
