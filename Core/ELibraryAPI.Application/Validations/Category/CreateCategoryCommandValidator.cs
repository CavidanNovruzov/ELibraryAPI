using ELibraryAPI.Application.Features.Commands.Category.CreateCategory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Category;

public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
