using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.DeleteTransaction;

public sealed class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommandRequest, Result>
{
    public Task<Result> Handle(DeleteTransactionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
