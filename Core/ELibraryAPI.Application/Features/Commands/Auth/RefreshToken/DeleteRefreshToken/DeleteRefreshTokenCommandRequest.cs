using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RefreshToken.DeleteRefreshToken;

public sealed record DeleteRefreshTokenCommandRequest(Guid Id) : IRequest<Result>;
