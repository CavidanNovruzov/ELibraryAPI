using ELibraryAPI.Application.Features.Commands.Basket.DeleteBasket;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Basket;

public sealed class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommandRequest>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
