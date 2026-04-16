using ELibraryAPI.Application.Features.Commands.ProductImage.UpdateProductImage;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductImage;

public sealed class UpdateProductImageCommandValidator : AbstractValidator<UpdateProductImageCommandRequest>
{
    public UpdateProductImageCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
