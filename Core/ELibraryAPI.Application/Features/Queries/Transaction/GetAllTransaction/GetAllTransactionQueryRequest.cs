using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Transaction.GetAllTransaction;

public sealed record GetAllTransactionQueryRequest : IRequest<Result<GetAllTransactionQueryResponse>>;
