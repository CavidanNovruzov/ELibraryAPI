using ELibraryAPI.Application.Features.Commands.BasketItem.CreateBasketItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.BasketItem;

public sealed class CreateBasketItemCommandValidator : AbstractValidator<CreateBasketItemCommandRequest>
{
    public CreateBasketItemCommandValidator()
    {
        RuleFor(x => x.BasketId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}
