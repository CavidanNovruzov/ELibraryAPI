using FluentValidation;

namespace ELibraryAPI.Application.Features.Commands.WishlistItem.MoveToBasket;

public sealed class MoveToBasketCommandValidator : AbstractValidator<MoveToBasketCommandRequest>
{
    public MoveToBasketCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Wishlist item ID is required.");
        RuleFor(x => x.BasketId).NotEmpty().WithMessage("Target basket ID is required.");
    }
}