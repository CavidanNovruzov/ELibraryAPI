using ELibraryAPI.Application.Abstractions.Services.Auth;
using ELibraryAPI.Application.Responses;
using MediatR;


namespace ELibraryAPI.Application.Features.Commands.Auth.AppUser.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, Result<RefreshTokenCommandResponse>>
{
    private readonly IAuthService _authService;

    public RefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<Result<RefreshTokenCommandResponse>> Handle(RefreshTokenCommandRequest request, CancellationToken ct)
    {
        var result = await _authService.RefreshTokenAsync(new()
        {
            RefreshToken = request.RefreshToken,
        }, ct);

        if (!result.IsSuccess)
            return Result<RefreshTokenCommandResponse>.Failure(result.Error!);

        return Result<RefreshTokenCommandResponse>.Success(new(
            result.Value!
        ));
    }
}
