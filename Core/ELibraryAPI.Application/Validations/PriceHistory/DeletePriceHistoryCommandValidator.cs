using ELibraryAPI.Application.Features.Commands.PriceHistory.DeletePriceHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.PriceHistory;

public sealed class DeletePriceHistoryCommandValidator : AbstractValidator<DeletePriceHistoryCommandRequest>
{
    public DeletePriceHistoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
