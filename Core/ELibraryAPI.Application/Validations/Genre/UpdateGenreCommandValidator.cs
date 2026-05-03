using ELibraryAPI.Application.Features.Commands.Genre.UpdateGenre;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Genre;

public sealed class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommandRequest>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
