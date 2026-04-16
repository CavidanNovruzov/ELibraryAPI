using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Stock.GetAllStock;

public sealed record GetAllStockQueryRequest : IRequest<Result<GetAllStockQueryResponse>>;
