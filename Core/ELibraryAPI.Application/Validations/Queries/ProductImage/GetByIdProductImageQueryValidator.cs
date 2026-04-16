using ELibraryAPI.Application.Features.Queries.ProductImage.GetByIdProductImage;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.ProductImage;

public sealed class GetByIdProductImageQueryValidator : AbstractValidator<GetByIdProductImageQueryRequest>
{
    public GetByIdProductImageQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
