using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Transaction.GetByIdTransaction;

public sealed class GetByIdTransactionQueryHandler : IRequestHandler<GetByIdTransactionQueryRequest, Result<GetByIdTransactionQueryResponse>>
{
    public Task<Result<GetByIdTransactionQueryResponse>> Handle(GetByIdTransactionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
