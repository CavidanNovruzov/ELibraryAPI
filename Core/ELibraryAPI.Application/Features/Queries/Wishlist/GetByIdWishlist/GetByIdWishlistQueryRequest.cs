using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Wishlist.GetByIdWishlist;

public sealed record GetByIdWishlistQueryRequest(Guid Id) : IRequest<Result<GetByIdWishlistQueryResponse>>;
