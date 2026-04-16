using ELibraryAPI.Application.Features.Commands.BasketItem.UpdateBasketItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.BasketItem;

public sealed class UpdateBasketItemCommandValidator : AbstractValidator<UpdateBasketItemCommandRequest>
{
    public UpdateBasketItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.BasketId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}
