using ELibraryAPI.Application.Features.Queries.Category.GetByIdCategory;
using FluentValidation;


namespace ELibraryAPI.Application.Validations.Category
{
    public sealed class GetByIdCategoryQueryValidator : AbstractValidator<GetByIdCategoryQueryRequest>
    {
        public GetByIdCategoryQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Category ID is required.")
                .NotEqual(Guid.Empty).WithMessage("Please provide a valid Category ID.");
        }
    }
}
