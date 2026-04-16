using ELibraryAPI.Application.Features.Commands.ProductImage.DeleteProductImage;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductImage;

public sealed class DeleteProductImageCommandValidator : AbstractValidator<DeleteProductImageCommandRequest>
{
    public DeleteProductImageCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
