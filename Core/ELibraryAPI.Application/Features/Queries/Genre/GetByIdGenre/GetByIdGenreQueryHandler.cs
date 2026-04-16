using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Genre.GetByIdGenre;

public sealed class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQueryRequest, Result<GetByIdGenreQueryResponse>>
{
    public Task<Result<GetByIdGenreQueryResponse>> Handle(GetByIdGenreQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
