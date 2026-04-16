using ELibraryAPI.Application.Features.Commands.ProductImage.CreateProductImage;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductImage;

public sealed class CreateProductImageCommandValidator : AbstractValidator<CreateProductImageCommandRequest>
{
    public CreateProductImageCommandValidator()
    {
        RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
