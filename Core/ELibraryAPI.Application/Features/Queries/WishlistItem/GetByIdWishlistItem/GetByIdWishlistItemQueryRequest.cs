using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.WishlistItem.GetByIdWishlistItem;

public sealed record GetByIdWishlistItemQueryRequest(Guid Id) : IRequest<Result<GetByIdWishlistItemQueryResponse>>;
