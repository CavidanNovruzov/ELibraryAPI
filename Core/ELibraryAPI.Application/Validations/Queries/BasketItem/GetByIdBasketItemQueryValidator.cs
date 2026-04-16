using ELibraryAPI.Application.Features.Queries.BasketItem.GetByIdBasketItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.BasketItem;

public sealed class GetByIdBasketItemQueryValidator : AbstractValidator<GetByIdBasketItemQueryRequest>
{
    public GetByIdBasketItemQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
