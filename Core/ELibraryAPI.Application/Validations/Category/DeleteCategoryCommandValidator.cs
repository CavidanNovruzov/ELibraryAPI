using ELibraryAPI.Application.Features.Commands.Category.DeleteCategory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Category;

public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
