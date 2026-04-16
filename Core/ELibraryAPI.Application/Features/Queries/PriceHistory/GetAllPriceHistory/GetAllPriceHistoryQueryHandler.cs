using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PriceHistory.GetAllPriceHistory;

public sealed class GetAllPriceHistoryQueryHandler : IRequestHandler<GetAllPriceHistoryQueryRequest, Result<GetAllPriceHistoryQueryResponse>>
{
    public Task<Result<GetAllPriceHistoryQueryResponse>> Handle(GetAllPriceHistoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
