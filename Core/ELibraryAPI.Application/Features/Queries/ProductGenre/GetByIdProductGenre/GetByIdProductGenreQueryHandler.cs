using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductGenre.GetByIdProductGenre;

public sealed class GetByIdProductGenreQueryHandler : IRequestHandler<GetByIdProductGenreQueryRequest, Result<GetByIdProductGenreQueryResponse>>
{
    public Task<Result<GetByIdProductGenreQueryResponse>> Handle(GetByIdProductGenreQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
