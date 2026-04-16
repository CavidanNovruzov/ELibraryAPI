using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Stock.GetByIdStock;

public sealed class GetByIdStockQueryHandler : IRequestHandler<GetByIdStockQueryRequest, Result<GetByIdStockQueryResponse>>
{
    public Task<Result<GetByIdStockQueryResponse>> Handle(GetByIdStockQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
