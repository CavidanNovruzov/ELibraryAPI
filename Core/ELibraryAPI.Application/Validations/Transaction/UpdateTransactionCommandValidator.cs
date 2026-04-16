using ELibraryAPI.Application.Features.Commands.Transaction.UpdateTransaction;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Transaction;

public sealed class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommandRequest>
{
    public UpdateTransactionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.ProviderResponse).NotEmpty();
        RuleFor(x => x.TransactionId).NotEmpty().MaximumLength(200);
    }
}
