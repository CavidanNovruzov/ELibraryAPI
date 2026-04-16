using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.RefreshToken.GetByIdRefreshToken;

public sealed class GetByIdRefreshTokenQueryHandler : IRequestHandler<GetByIdRefreshTokenQueryRequest, Result<GetByIdRefreshTokenQueryResponse>>
{
    public Task<Result<GetByIdRefreshTokenQueryResponse>> Handle(GetByIdRefreshTokenQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
