using ELibraryAPI.Application.Features.Queries.Basket.GetByIdBasket;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Basket;

public sealed class GetByIdBasketQueryValidator : AbstractValidator<GetByIdBasketQueryRequest>
{
    public GetByIdBasketQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
