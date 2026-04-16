using ELibraryAPI.Application.Features.Commands.PriceHistory.CreatePriceHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.PriceHistory;

public sealed class CreatePriceHistoryCommandValidator : AbstractValidator<CreatePriceHistoryCommandRequest>
{
    public CreatePriceHistoryCommandValidator()
    {
        RuleFor(x => x.NewPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.OldPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
