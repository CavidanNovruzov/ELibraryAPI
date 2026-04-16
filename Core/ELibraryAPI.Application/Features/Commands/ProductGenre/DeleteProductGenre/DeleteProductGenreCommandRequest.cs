using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.DeleteProductGenre;

public sealed record DeleteProductGenreCommandRequest(Guid Id) : IRequest<Result>;
