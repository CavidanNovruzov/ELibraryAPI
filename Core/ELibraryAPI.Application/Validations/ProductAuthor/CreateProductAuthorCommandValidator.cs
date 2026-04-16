using ELibraryAPI.Application.Features.Commands.ProductAuthor.CreateProductAuthor;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductAuthor;

public sealed class CreateProductAuthorCommandValidator : AbstractValidator<CreateProductAuthorCommandRequest>
{
    public CreateProductAuthorCommandValidator()
    {
        RuleFor(x => x.AuthorId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
