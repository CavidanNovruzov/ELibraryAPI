using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Wishlist.GetAllWishlist;

public sealed class GetAllWishlistQueryHandler : IRequestHandler<GetAllWishlistQueryRequest, Result<GetAllWishlistQueryResponse>>
{
    public Task<Result<GetAllWishlistQueryResponse>> Handle(GetAllWishlistQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
