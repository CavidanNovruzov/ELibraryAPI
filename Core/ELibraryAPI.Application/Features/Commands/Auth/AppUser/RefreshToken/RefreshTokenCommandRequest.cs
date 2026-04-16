using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Auth.AppUser.RefreshToken;

public record RefreshTokenCommandRequest(string RefreshToken) : IRequest<Result<RefreshTokenCommandResponse>>;

