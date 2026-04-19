using ELibraryAPI.Application.Features.Commands.Product.CreateProduct;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Product;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.CoverTypeId).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.DiscountPrice).GreaterThanOrEqualTo(0).LessThanOrEqualTo(x => x.SalePrice).When(x => x.DiscountPrice != null);
        RuleFor(x => x.ISBN).NotEmpty().Length(10, 20);
        RuleFor(x => x.LanguageId).NotEmpty();
        RuleFor(x => x.PageCount).GreaterThan(0);
        RuleFor(x => x.PublisherId).NotEmpty();
        RuleFor(x => x.SalePrice).GreaterThan(0);
        RuleFor(x => x.SubCategoryId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.PublicationYear)
        .GreaterThan(1000)
        .LessThanOrEqualTo(DateTime.UtcNow.Year);
    }
}
