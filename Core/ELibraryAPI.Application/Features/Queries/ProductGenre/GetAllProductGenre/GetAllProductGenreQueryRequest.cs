using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductGenre.GetAllProductGenre;

public sealed record GetAllProductGenreQueryRequest : IRequest<Result<GetAllProductGenreQueryResponse>>;
