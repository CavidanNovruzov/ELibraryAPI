using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserSearchHistory.CreateUserSearchHistory;

public sealed class CreateUserSearchHistoryCommandHandler : IRequestHandler<CreateUserSearchHistoryCommandRequest, Result<CreateUserSearchHistoryCommandResponse>>
{
    public Task<Result<CreateUserSearchHistoryCommandResponse>> Handle(CreateUserSearchHistoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
