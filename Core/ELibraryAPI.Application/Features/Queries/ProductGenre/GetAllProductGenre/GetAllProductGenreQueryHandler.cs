using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductGenre.GetAllProductGenre;

public sealed class GetAllProductGenreQueryHandler : IRequestHandler<GetAllProductGenreQueryRequest, Result<GetAllProductGenreQueryResponse>>
{
    public Task<Result<GetAllProductGenreQueryResponse>> Handle(GetAllProductGenreQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
