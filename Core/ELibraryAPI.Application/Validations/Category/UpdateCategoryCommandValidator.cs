using ELibraryAPI.Application.Features.Commands.Category.UpdateCategory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Category;

public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
