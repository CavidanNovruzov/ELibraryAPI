using ELibraryAPI.Application.Features.Commands.Genre.CreateGenre;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Genre;

public sealed class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommandRequest>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Genre name is required.")
            .MaximumLength(100).WithMessage("Genre name cannot exceed 100 characters.");
    }
}