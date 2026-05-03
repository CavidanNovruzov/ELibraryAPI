using FluentValidation;
using ELibraryAPI.Application.Features.Commands.Basket.CreateBasket;

namespace ELibraryAPI.Application.Validations.Basket;

public sealed class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommandRequest>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User identification is required for a basket.");

        RuleFor(x => x.TotalPrice)
            .Equal(0).WithMessage("A new basket must start with a total price of 0.");
    }
}