using ELibraryAPI.Application.Features.Queries.Category.GetByIdCategory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Category;

public sealed class GetByIdCategoryQueryValidator : AbstractValidator<GetByIdCategoryQueryRequest>
{
    public GetByIdCategoryQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
