using ELibraryAPI.Application.Features.Commands.Author.UpdateAuthor;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Author;

public sealed class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommandRequest>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Biography).NotEmpty();
        RuleFor(x => x.Country).NotEmpty().MaximumLength(100);
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.ImagePath).NotEmpty().MaximumLength(1000);
    }
}
