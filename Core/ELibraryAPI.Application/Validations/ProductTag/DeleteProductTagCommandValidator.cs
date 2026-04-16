using ELibraryAPI.Application.Features.Commands.ProductTag.DeleteProductTag;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductTag;

public sealed class DeleteProductTagCommandValidator : AbstractValidator<DeleteProductTagCommandRequest>
{
    public DeleteProductTagCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
