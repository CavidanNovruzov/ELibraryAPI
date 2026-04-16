using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RefreshToken.CreateRefreshToken;

public sealed class CreateRefreshTokenCommandHandler : IRequestHandler<CreateRefreshTokenCommandRequest, Result<CreateRefreshTokenCommandResponse>>
{
    public Task<Result<CreateRefreshTokenCommandResponse>> Handle(CreateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
