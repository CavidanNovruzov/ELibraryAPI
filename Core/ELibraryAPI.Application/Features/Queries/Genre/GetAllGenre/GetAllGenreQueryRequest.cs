using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Genre.GetAllGenre;

public sealed record GetAllGenreQueryRequest : IRequest<Result<GetAllGenreQueryResponse>>;
