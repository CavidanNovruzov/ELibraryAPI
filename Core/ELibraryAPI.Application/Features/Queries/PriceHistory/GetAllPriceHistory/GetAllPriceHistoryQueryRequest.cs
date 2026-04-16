using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PriceHistory.GetAllPriceHistory;

public sealed record GetAllPriceHistoryQueryRequest : IRequest<Result<GetAllPriceHistoryQueryResponse>>;
