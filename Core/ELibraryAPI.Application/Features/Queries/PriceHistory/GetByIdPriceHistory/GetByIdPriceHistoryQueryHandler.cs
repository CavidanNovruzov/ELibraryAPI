using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PriceHistory.GetByIdPriceHistory;

public sealed class GetByIdPriceHistoryQueryHandler : IRequestHandler<GetByIdPriceHistoryQueryRequest, Result<GetByIdPriceHistoryQueryResponse>>
{
    public Task<Result<GetByIdPriceHistoryQueryResponse>> Handle(GetByIdPriceHistoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
