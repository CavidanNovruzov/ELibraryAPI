using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserSearchHistory.DeleteUserSearchHistory;

public sealed class DeleteUserSearchHistoryCommandHandler : IRequestHandler<DeleteUserSearchHistoryCommandRequest, Result>
{
    public Task<Result> Handle(DeleteUserSearchHistoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
