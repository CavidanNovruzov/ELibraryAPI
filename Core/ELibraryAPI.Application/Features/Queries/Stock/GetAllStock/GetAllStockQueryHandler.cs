using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Stock.GetAllStock;

public sealed class GetAllStockQueryHandler : IRequestHandler<GetAllStockQueryRequest, Result<GetAllStockQueryResponse>>
{
    public Task<Result<GetAllStockQueryResponse>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
