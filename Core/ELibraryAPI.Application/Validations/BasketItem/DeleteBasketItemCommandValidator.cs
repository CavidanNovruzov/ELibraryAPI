using ELibraryAPI.Application.Features.Commands.BasketItem.DeleteBasketItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.BasketItem;

public sealed class DeleteBasketItemCommandValidator : AbstractValidator<DeleteBasketItemCommandRequest>
{
    public DeleteBasketItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
