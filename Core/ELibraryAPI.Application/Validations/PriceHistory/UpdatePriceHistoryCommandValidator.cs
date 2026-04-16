using ELibraryAPI.Application.Features.Commands.PriceHistory.UpdatePriceHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.PriceHistory;

public sealed class UpdatePriceHistoryCommandValidator : AbstractValidator<UpdatePriceHistoryCommandRequest>
{
    public UpdatePriceHistoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.NewPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.OldPrice).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
