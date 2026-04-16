using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.CreateTransaction;

public sealed class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommandRequest, Result<CreateTransactionCommandResponse>>
{
    public Task<Result<CreateTransactionCommandResponse>> Handle(CreateTransactionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
