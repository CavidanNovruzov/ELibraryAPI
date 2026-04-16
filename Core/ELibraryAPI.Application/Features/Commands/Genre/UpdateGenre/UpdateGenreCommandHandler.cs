using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Genre.UpdateGenre;

public sealed class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest, Result<UpdateGenreCommandResponse>>
{
    public Task<Result<UpdateGenreCommandResponse>> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
