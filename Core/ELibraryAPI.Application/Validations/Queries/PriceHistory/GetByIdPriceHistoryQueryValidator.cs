using ELibraryAPI.Application.Features.Queries.PriceHistory.GetByIdPriceHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.PriceHistory;

public sealed class GetByIdPriceHistoryQueryValidator : AbstractValidator<GetByIdPriceHistoryQueryRequest>
{
    public GetByIdPriceHistoryQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
