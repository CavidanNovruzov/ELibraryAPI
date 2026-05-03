using ELibraryAPI.Application.Features.Commands.Auth.ForgotPassword;
using ELibraryAPI.Application.Features.Commands.Auth.LoginUser;
using ELibraryAPI.Application.Features.Commands.Auth.RefreshToken;
using ELibraryAPI.Application.Features.Commands.Auth.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers.Auth;

public sealed class AuthController : ApiControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));
}