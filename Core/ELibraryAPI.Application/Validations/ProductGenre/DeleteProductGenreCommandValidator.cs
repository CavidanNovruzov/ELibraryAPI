using ELibraryAPI.Application.Features.Commands.ProductGenre.DeleteProductGenre;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductGenre;

public sealed class DeleteProductGenreCommandValidator : AbstractValidator<DeleteProductGenreCommandRequest>
{
    public DeleteProductGenreCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
