using ELibraryAPI.Application.Features.Commands.Transaction.DeleteTransaction;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Transaction;

public sealed class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommandRequest>
{
    public DeleteTransactionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
