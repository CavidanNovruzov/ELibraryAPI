using ELibraryAPI.API.Controllers;
using ELibraryAPI.Application.Features.Commands.Auth.AppUser.ChangePassword;
using ELibraryAPI.Application.Features.Commands.Auth.AppUser.ConfirmEmail;
using ELibraryAPI.Application.Features.Commands.Auth.AppUser.RegistrUser;
using ELibraryAPI.Application.Features.Commands.Auth.AppUser.UpdateProfile;
using ELibraryAPI.Application.Features.Commands.Auth.LogoutUser;
using ELibraryAPI.Application.Features.Queries.Auth.AppUser.GetAllUsers;
using ELibraryAPI.Application.Features.Queries.Auth.AppUser.GetMyProfile;
using ELibraryAPI.Application.Features.Queries.Auth.AppUser.GetUserById;
using ELibraryAPI.Domain.Constants;
using ELibraryAPI.Infrastructure.Security.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
[Route("api/[controller]")]
public sealed class UsersController : ApiControllerBase 
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator) => _mediator = mediator;
    private Guid? CurrentUserId =>
        User.Identity?.IsAuthenticated == true
        ? Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!)
        : null;

    [AllowAnonymous] 
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrUserCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [AllowAnonymous]
    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("update-profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileCommandRequest request, CancellationToken ct)
    {
        if (CurrentUserId == null) return Unauthorized();
        return FromResult(await _mediator.Send(request with { UserId = CurrentUserId.Value }, ct));
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommandRequest request, CancellationToken ct)
    {
        if (CurrentUserId == null) return Unauthorized();
        return FromResult(await _mediator.Send(request with { UserId = CurrentUserId.Value }, ct));
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout(CancellationToken ct)
    {
        if (CurrentUserId == null) return Unauthorized();
        return FromResult(await _mediator.Send(new LogoutUserCommandRequest(CurrentUserId.Value), ct));
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMyProfile(CancellationToken ct)
    => FromResult(await _mediator.Send(new GetMyProfileQueryRequest(CurrentUserId.Value), ct));

    [HttpGet]
    [HasPermission(AuthorizePermissions.Administration.ManageRoles)]
    public async Task<IActionResult> GetAllUsers(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllUsersQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    [HasPermission(AuthorizePermissions.Administration.ManageRoles)]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetUserByIdQueryRequest(id), ct));
}