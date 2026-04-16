using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.CreateProductGenre;

public sealed class CreateProductGenreCommandHandler : IRequestHandler<CreateProductGenreCommandRequest, Result<CreateProductGenreCommandResponse>>
{
    public Task<Result<CreateProductGenreCommandResponse>> Handle(CreateProductGenreCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
