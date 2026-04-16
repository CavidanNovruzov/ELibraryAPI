using ELibraryAPI.Application.Features.Commands.ProductAuthor.DeleteProductAuthor;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductAuthor;

public sealed class DeleteProductAuthorCommandValidator : AbstractValidator<DeleteProductAuthorCommandRequest>
{
    public DeleteProductAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
