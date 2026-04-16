using ELibraryAPI.Application.Dtos.Auth;
using Microsoft.AspNetCore.Identity;


namespace ELibraryAPI.Application.Features.Commands.Auth.AppUser.LoginUser;

public class LoginUserCommandResponse
{
    public TokenResponse Token { get; set; } = null!;
}
