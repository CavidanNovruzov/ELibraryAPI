using ELibraryAPI.Application.Features.Queries.Transaction.GetByIdTransaction;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Transaction;

public sealed class GetByIdTransactionQueryValidator : AbstractValidator<GetByIdTransactionQueryRequest>
{
    public GetByIdTransactionQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
