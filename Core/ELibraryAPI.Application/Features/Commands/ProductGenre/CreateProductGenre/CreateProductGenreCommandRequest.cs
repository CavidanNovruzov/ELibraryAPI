using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.CreateProductGenre;

public sealed record CreateProductGenreCommandRequest(
    Guid GenreId,
    Guid ProductId
) : IRequest<Result<CreateProductGenreCommandResponse>>;
