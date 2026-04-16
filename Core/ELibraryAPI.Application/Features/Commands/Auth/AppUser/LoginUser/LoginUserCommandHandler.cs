using ELibraryAPI.Application.Abstractions.Services.Auth;
using ELibraryAPI.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ELibraryAPI.Application.Features.Commands.Auth.AppUser.LoginUser;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, Result<LoginUserCommandResponse>>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<Result<LoginUserCommandResponse>> Handle(
        LoginUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(new()
        {
            Login = request.Login,
            Password = request.Password
        }, cancellationToken);

        if (!result.IsSuccess)
            return Result<LoginUserCommandResponse>.Failure(result.Error);

        return Result<LoginUserCommandResponse>.Success(new LoginUserCommandResponse
        {
             Token = result.Value
        });
    }
}