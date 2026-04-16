using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserSearchHistory.UpdateUserSearchHistory;

public sealed class UpdateUserSearchHistoryCommandHandler : IRequestHandler<UpdateUserSearchHistoryCommandRequest, Result<UpdateUserSearchHistoryCommandResponse>>
{
    public Task<Result<UpdateUserSearchHistoryCommandResponse>> Handle(UpdateUserSearchHistoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
