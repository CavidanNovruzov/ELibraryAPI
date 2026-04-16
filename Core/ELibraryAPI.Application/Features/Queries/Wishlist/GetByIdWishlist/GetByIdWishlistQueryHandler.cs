using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Wishlist.GetByIdWishlist;

public sealed class GetByIdWishlistQueryHandler : IRequestHandler<GetByIdWishlistQueryRequest, Result<GetByIdWishlistQueryResponse>>
{
    public Task<Result<GetByIdWishlistQueryResponse>> Handle(GetByIdWishlistQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
