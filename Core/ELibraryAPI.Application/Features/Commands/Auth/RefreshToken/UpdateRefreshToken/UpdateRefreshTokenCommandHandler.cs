using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RefreshToken.UpdateRefreshToken;

public sealed class UpdateRefreshTokenCommandHandler : IRequestHandler<UpdateRefreshTokenCommandRequest, Result<UpdateRefreshTokenCommandResponse>>
{
    public Task<Result<UpdateRefreshTokenCommandResponse>> Handle(UpdateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
