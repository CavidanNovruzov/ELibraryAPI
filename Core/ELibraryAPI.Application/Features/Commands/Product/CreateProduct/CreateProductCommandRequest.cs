using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Product.CreateProduct;

public sealed record CreateProductCommandRequest(
    Guid CoverTypeId,
    string Description,
    decimal? DiscountPrice,
    string ISBN,
    Guid LanguageId,
    int PageCount,
    Guid PublisherId,
    decimal SalePrice,
    Guid SubCategoryId,
    string Title,
    int PublicationYear
) : IRequest<Result<CreateProductCommandResponse>>;
