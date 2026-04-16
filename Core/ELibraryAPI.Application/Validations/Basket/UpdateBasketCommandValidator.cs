using ELibraryAPI.Application.Features.Commands.Basket.UpdateBasket;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Basket;

public sealed class UpdateBasketCommandValidator : AbstractValidator<UpdateBasketCommandRequest>
{
    public UpdateBasketCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.TotalPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
