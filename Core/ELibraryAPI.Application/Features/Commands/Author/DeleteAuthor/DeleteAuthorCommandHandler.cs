using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Author.DeleteAuthor;

public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, Result>
{
    public Task<Result> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
