using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.WishlistItem.GetAllWishlistItem;

public sealed record GetAllWishlistItemQueryRequest : IRequest<Result<GetAllWishlistItemQueryResponse>>;
