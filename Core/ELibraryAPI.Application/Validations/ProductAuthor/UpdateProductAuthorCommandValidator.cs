using ELibraryAPI.Application.Features.Commands.ProductAuthor.UpdateProductAuthor;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductAuthor;

public sealed class UpdateProductAuthorCommandValidator : AbstractValidator<UpdateProductAuthorCommandRequest>
{
    public UpdateProductAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.AuthorId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
