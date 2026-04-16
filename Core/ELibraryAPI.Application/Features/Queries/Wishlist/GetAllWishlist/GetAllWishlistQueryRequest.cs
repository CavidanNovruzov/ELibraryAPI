using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Wishlist.GetAllWishlist;

public sealed record GetAllWishlistQueryRequest : IRequest<Result<GetAllWishlistQueryResponse>>;
