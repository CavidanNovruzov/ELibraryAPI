using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RefreshToken.CreateRefreshToken;

public sealed record CreateRefreshTokenCommandRequest(
    DateTime ExpiresAt,
    string TokenHash,
    Guid UserId
) : IRequest<Result<CreateRefreshTokenCommandResponse>>;
