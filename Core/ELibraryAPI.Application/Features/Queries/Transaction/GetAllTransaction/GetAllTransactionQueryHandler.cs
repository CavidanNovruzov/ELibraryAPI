using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Transaction.GetAllTransaction;

public sealed class GetAllTransactionQueryHandler : IRequestHandler<GetAllTransactionQueryRequest, Result<GetAllTransactionQueryResponse>>
{
    public Task<Result<GetAllTransactionQueryResponse>> Handle(GetAllTransactionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
