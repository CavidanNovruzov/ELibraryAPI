using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.UserSearchHistory.GetByIdUserSearchHistory;

public sealed record GetByIdUserSearchHistoryQueryRequest(Guid Id) : IRequest<Result<GetByIdUserSearchHistoryQueryResponse>>;
