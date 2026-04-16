using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.UpdateProductGenre;

public sealed class UpdateProductGenreCommandHandler : IRequestHandler<UpdateProductGenreCommandRequest, Result<UpdateProductGenreCommandResponse>>
{
    public Task<Result<UpdateProductGenreCommandResponse>> Handle(UpdateProductGenreCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
