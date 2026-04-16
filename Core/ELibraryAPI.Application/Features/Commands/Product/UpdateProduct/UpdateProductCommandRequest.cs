using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Product.UpdateProduct;

public sealed record UpdateProductCommandRequest(
    Guid Id,
    Guid CoverTypeId,
    string Description,
    decimal? DiscountPrice,
    string ISBN,
    Guid LanguageId,
    int PageCount,
    Guid PublisherId,
    decimal SalePrice,
    Guid SubCategoryId,
    string Title
) : IRequest<Result<UpdateProductCommandResponse>>;
