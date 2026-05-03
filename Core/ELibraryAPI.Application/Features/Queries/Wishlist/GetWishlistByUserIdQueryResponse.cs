using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Features.Queries.Wishlist;

public sealed record GetWishlistByUserIdQueryResponse(Guid WishlistId, List<WishlistItemDto> Items);

public sealed record WishlistItemDto(Guid ProductId, string Title, decimal Price, string ImageUrl);