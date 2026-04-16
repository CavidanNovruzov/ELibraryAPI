using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Genre.CreateGenre;

public sealed class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommandRequest, Result<CreateGenreCommandResponse>>
{
    public Task<Result<CreateGenreCommandResponse>> Handle(CreateGenreCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
