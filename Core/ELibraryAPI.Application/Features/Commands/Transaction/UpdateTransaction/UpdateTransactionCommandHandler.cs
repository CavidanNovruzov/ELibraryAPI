using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.UpdateTransaction;

public sealed class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommandRequest, Result<UpdateTransactionCommandResponse>>
{
    public Task<Result<UpdateTransactionCommandResponse>> Handle(UpdateTransactionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
