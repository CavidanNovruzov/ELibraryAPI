using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductGenre.GetByIdProductGenre;

public sealed record GetByIdProductGenreQueryRequest(Guid Id) : IRequest<Result<GetByIdProductGenreQueryResponse>>;
