using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserSearchHistory.UpdateUserSearchHistory;

public sealed record UpdateUserSearchHistoryCommandRequest(
    Guid Id,
    string SearchQuery,
    Guid UserId
) : IRequest<Result<UpdateUserSearchHistoryCommandResponse>>;
