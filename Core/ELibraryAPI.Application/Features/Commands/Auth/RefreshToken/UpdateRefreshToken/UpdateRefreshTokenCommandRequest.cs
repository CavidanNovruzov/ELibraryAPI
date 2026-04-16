using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RefreshToken.UpdateRefreshToken;

public sealed record UpdateRefreshTokenCommandRequest(
    Guid Id,
    DateTime ExpiresAt,
    string TokenHash,
    Guid UserId
) : IRequest<Result<UpdateRefreshTokenCommandResponse>>;
