using ELibraryAPI.Application.Features.Commands.Basket.CreateBasket;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Basket;

public sealed class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommandRequest>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(x => x.TotalPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
