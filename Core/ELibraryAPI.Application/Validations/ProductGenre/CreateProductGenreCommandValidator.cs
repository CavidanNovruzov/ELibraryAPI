using ELibraryAPI.Application.Features.Commands.ProductGenre.CreateProductGenre;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductGenre;

public sealed class CreateProductGenreCommandValidator : AbstractValidator<CreateProductGenreCommandRequest>
{
    public CreateProductGenreCommandValidator()
    {
        RuleFor(x => x.GenreId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
