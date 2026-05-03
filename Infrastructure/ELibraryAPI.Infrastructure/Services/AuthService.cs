using ELibraryAPI.Application.Abstractions.Services;
using ELibraryAPI.Application.Abstractions.Services.Auth;
using ELibraryAPI.Application.Dtos.Auth;
using ELibraryAPI.Application.Options;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace ELibraryAPI.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IEmailSender _emailSender;
    private readonly SmtpOptions _emailOptions;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly JwtOptions _jwtOptions;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IJwtTokenGenerator jwtGenerator,
        IRefreshTokenService refreshTokenService,
        IOptions<JwtOptions> jwtOptions,
        IEmailSender emailSender,
        IOptions<SmtpOptions> emailOptions,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerator = jwtGenerator;
        _refreshTokenService = refreshTokenService;
        _jwtOptions = jwtOptions.Value;
        _emailSender = emailSender;
        _emailOptions = emailOptions.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> RegisterAsync(RegistrRequest request, CancellationToken ct = default)
    {
        var user = new AppUser
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return Result<Guid>.Failure(string.Join(" ", result.Errors.Select(e => e.Description)));

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = $"{_emailOptions.ConfirmEmailBaseUrl}?userId={user.Id}&token={WebUtility.UrlEncode(token)}";

        await _emailSender.SendEmailAsync(
            user.Email!,
            "Account Confirmation",
            $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

        return Result<Guid>.Success(user.Id);
    }

    public async Task<Result<TokenResponse>> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var user = await _userManager.FindByNameAsync(request.Login)
           ?? await _userManager.FindByEmailAsync(request.Login);

        if (user == null)
            return Result<TokenResponse>.Failure("Invalid username or password.");

        if (!user.EmailConfirmed)
            return Result<TokenResponse>.Failure("Please confirm your email address first.");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
            return Result<TokenResponse>.Failure("Invalid username or password.");

        var roles = await _userManager.GetRolesAsync(user);
        var permissions = await GetUserPermissionsAsync(user.Id, ct);

        var accessToken = _jwtGenerator.GenerateAccessToken(user, roles, permissions);
        var refreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user);

        return Result<TokenResponse>.Success(new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Expiration = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes)
        });
    }

    public async Task<Result<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken ct = default)
    {
        var user = await _refreshTokenService.ValidateAndConsumeAsync(request.RefreshToken);

        if (user == null)
            return Result<TokenResponse>.Failure("Session expired. Please login again.");

        var roles = await _userManager.GetRolesAsync(user);
        var permissions = await GetUserPermissionsAsync(user.Id, ct);

        var accessToken = _jwtGenerator.GenerateAccessToken(user, roles, permissions);
        var newRefreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user);

        return Result<TokenResponse>.Success(new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            Expiration = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes)
        });
    }

    public async Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return Result.Failure("User not found.");

        var result = await _userManager.ConfirmEmailAsync(user, request.Token);

        if (!result.Succeeded)
            return Result.Failure("Invalid or expired confirmation link.");

        return Result.Success();
    }

    public async Task<HashSet<string>> GetUserPermissionsAsync(Guid userId, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null) return new HashSet<string>();

        var userRoles = await _userManager.GetRolesAsync(user);

        var rolePermissions = await _unitOfWork.ReadRepository<RolePermission, Guid>().Table
            .Include(rp => rp.Permission)
            .Include(rp => rp.Role)
            .Where(rp => userRoles.Contains(rp.Role.Name!))
            .Select(rp => rp.Permission.Key)
            .ToListAsync(ct);

        var userPermissions = await _unitOfWork.ReadRepository<AppUserPermission, Guid>().Table
            .Include(up => up.Permission)
            .Where(up => up.UserId == userId)
            .Select(up => up.Permission.Key)
            .ToListAsync(ct);

        return rolePermissions.Union(userPermissions).ToHashSet();
    }
}