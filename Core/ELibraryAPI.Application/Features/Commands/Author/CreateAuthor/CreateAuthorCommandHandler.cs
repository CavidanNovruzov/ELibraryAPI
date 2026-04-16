using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Author.CreateAuthor;

public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, Result<CreateAuthorCommandResponse>>
{
    public Task<Result<CreateAuthorCommandResponse>> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
