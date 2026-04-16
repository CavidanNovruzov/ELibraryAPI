using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Transaction.GetByIdTransaction;

public sealed record GetByIdTransactionQueryRequest(Guid Id) : IRequest<Result<GetByIdTransactionQueryResponse>>;
