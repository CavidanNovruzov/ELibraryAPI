using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PriceHistory.GetByIdPriceHistory;

public sealed record GetByIdPriceHistoryQueryRequest(Guid Id) : IRequest<Result<GetByIdPriceHistoryQueryResponse>>;
