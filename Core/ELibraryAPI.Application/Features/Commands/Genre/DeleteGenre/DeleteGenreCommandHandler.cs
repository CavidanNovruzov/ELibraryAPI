using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Genre.DeleteGenre;

public sealed class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommandRequest, Result>
{
    public Task<Result> Handle(DeleteGenreCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
