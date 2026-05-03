using ELibraryAPI.Application.Features.Queries.Wishlist.GetWishlistByUserId;
using ELibraryAPI.Application.Responses;
using MediatR;



namespace ELibraryAPI.Application.Features.Queries.Wishlist;

public sealed record GetWishlistByUserIdQueryRequest(Guid UserId) : IRequest<Result<GetWishlistByUserIdQueryResponse>>;
