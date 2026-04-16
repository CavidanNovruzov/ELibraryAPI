using ELibraryAPI.Application.Features.Queries.Stock.GetByIdStock;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Stock;

public sealed class GetByIdStockQueryValidator : AbstractValidator<GetByIdStockQueryRequest>
{
    public GetByIdStockQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
