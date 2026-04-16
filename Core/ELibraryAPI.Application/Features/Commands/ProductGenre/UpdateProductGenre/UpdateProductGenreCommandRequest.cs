using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.UpdateProductGenre;

public sealed record UpdateProductGenreCommandRequest(
    Guid Id,
    Guid GenreId,
    Guid ProductId
) : IRequest<Result<UpdateProductGenreCommandResponse>>;
