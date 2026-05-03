using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Product.GetAllProduct;

public sealed record GetAllProductQueryRequest(
    int Page = 1,
    int Size = 20,
    string? Search = null,
    Guid? CategoryId = null,
    Guid? SubCategoryId = null,
    Guid? AuthorId = null,
    Guid? GenreId = null,
    decimal? MinPrice = null,
    decimal? MaxPrice = null,
    string? SortBy = null, // "PriceAsc", "PriceDesc", "Newest", "TopRated"
    bool? IsInDiscount = null
) : IRequest<Result<GetAllProductQueryResponse>>;
