using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Stock.GetByIdStock;

public sealed record GetByIdStockQueryRequest(Guid Id) : IRequest<Result<GetByIdStockQueryResponse>>;
