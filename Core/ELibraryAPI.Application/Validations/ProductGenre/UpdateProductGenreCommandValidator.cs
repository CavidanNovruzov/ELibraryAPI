using ELibraryAPI.Application.Features.Commands.ProductGenre.UpdateProductGenre;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductGenre;

public sealed class UpdateProductGenreCommandValidator : AbstractValidator<UpdateProductGenreCommandRequest>
{
    public UpdateProductGenreCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.GenreId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
