using FluentValidation;
using ELibraryAPI.Application.Features.Commands.Author.CreateAuthor;

namespace ELibraryAPI.Application.Validations.Author;

public sealed class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommandRequest>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(200).WithMessage("Full name cannot exceed 200 characters.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100).WithMessage("Country name is too long.");

        RuleFor(x => x.Biography)
            .NotEmpty().WithMessage("Biography cannot be empty.");

        RuleFor(x => x.ImagePath)
            .MaximumLength(1000).WithMessage("Image path is too long.");
    }
}