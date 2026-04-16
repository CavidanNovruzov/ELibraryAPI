using ELibraryAPI.Application.Features.Commands.Transaction.CreateTransaction;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Transaction;

public sealed class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommandRequest>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.ProviderResponse).NotEmpty();
        RuleFor(x => x.TransactionId).NotEmpty().MaximumLength(200);
    }
}
