using ELibraryAPI.Application.Features.Queries.Product.GetByIdProduct;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Product;

public sealed class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQueryRequest>
{
    public GetByIdProductQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
