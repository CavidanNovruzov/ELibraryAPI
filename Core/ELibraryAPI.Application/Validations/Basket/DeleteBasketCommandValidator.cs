using FluentValidation;
using ELibraryAPI.Application.Features.Commands.Basket.DeleteBasket;

namespace ELibraryAPI.Application.Validations.Basket;

public sealed class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommandRequest>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Basket ID is required.");
    }
}