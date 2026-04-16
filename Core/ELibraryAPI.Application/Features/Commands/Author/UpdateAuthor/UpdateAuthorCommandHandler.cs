using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Author.UpdateAuthor;

public sealed class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, Result<UpdateAuthorCommandResponse>>
{
    public Task<Result<UpdateAuthorCommandResponse>> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
