using FluentValidation;
using ELibraryAPI.Application.Features.Commands.Category.DeleteCategory;

namespace ELibraryAPI.Application.Validations.Category;

public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.");
    }
}