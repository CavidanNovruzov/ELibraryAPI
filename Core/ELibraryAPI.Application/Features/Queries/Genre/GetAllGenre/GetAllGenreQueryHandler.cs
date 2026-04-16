using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Genre.GetAllGenre;

public sealed class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQueryRequest, Result<GetAllGenreQueryResponse>>
{
    public Task<Result<GetAllGenreQueryResponse>> Handle(GetAllGenreQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
