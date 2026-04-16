using ELibraryAPI.Application.Features.Queries.SubCategory.GetByIdSubCategory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.SubCategory;

public sealed class GetByIdSubCategoryQueryValidator : AbstractValidator<GetByIdSubCategoryQueryRequest>
{
    public GetByIdSubCategoryQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
