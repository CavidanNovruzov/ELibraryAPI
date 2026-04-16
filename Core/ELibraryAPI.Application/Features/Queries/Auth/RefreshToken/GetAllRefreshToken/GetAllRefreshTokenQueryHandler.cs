using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.RefreshToken.GetAllRefreshToken;

public sealed class GetAllRefreshTokenQueryHandler : IRequestHandler<GetAllRefreshTokenQueryRequest, Result<GetAllRefreshTokenQueryResponse>>
{
    public Task<Result<GetAllRefreshTokenQueryResponse>> Handle(GetAllRefreshTokenQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
