using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RefreshToken.DeleteRefreshToken;

public sealed class DeleteRefreshTokenCommandHandler : IRequestHandler<DeleteRefreshTokenCommandRequest, Result>
{
    public Task<Result> Handle(DeleteRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
