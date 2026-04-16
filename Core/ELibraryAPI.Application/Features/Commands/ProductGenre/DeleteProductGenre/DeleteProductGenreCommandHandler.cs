using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.DeleteProductGenre;

public sealed class DeleteProductGenreCommandHandler : IRequestHandler<DeleteProductGenreCommandRequest, Result>
{
    public Task<Result> Handle(DeleteProductGenreCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
