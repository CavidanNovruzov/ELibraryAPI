using ELibraryAPI.Application.Abstractions.Services;
using ELibraryAPI.Application.Abstractions.Services.Auth;
using ELibraryAPI.Application.Dtos.Auth;
using ELibraryAPI.Application.Options;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
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

    public AuthService(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IJwtTokenGenerator jwtGenerator,
        IRefreshTokenService refreshTokenService,
        IOptions<JwtOptions> jwtOptions,
        IEmailSender emailSender,
        IOptions<SmtpOptions> emailOptions
    )
    {   _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerator = jwtGenerator;
        _refreshTokenService = refreshTokenService;
        _jwtOptions = jwtOptions.Value;
        _emailSender = emailSender;
        _emailOptions = emailOptions.Value;
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

        // E-mail təsdiq tokeni yaradırıq
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        // Təsdiq linki hazırlayırıq (URL encode mütləqdir)
        var confirmationLink = $"{_emailOptions.ConfirmEmailBaseUrl}?userId={user.Id}&token={WebUtility.UrlEncode(token)}";

        // E-maili asinxron göndəririk 
        await _emailSender.SendEmailAsync(
            user.Email,
            "Hesabın Təsdiqlənməsi",
            $"Zəhmət olmasa hesabınızı təsdiqləmək üçün <a href='{confirmationLink}'>bura klikləyin</a>.");

        return Result<Guid>.Success(user.Id);
    }
    public async Task<Result<TokenResponse>> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var user = await _userManager.FindByNameAsync(request.Login)
           ?? await _userManager.FindByEmailAsync(request.Login);

        if (user == null)
            return Result<TokenResponse>.Failure("İstifadəçi adı və ya şifrə yanlışdır.");

        // E-mail təsdiqlənməyibsə login-ə icazə vermə (Opsional)
        if (!user.EmailConfirmed)
            return Result<TokenResponse>.Failure("Zəhmət olmasa əvvəlcə e-mail ünvanınızı təsdiqləyin.");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
            return Result<TokenResponse>.Failure("İstifadəçi adı və ya şifrə yanlışdır.");

        var roles = await _userManager.GetRolesAsync(user);

        // Tokenləri yaradırıq
        var accessToken = _jwtGenerator.GenerateAccessToken(user, roles);
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
        // 1. Refresh Token vasitəsilə istifadəçini tapırıq və köhnə tokeni ləğv edirik
        var user = await _refreshTokenService.ValidateAndConsumeAsync(request.RefreshToken);

        // 2. Əgər token yanlışdırsa, vaxtı bitibsə və ya oğurlanıbsa (Consumed) null qayıdacaq
        if (user == null)
            return Result<TokenResponse>.Failure("Sessiya vaxtı bitib. Zəhmət olmasa yenidən daxil olun.");

        // 3. İstifadəçinin hazırkı rollarını götürürük
        var roles = await _userManager.GetRolesAsync(user);

        // 4. Yeni bir Access Token (JWT) yaradırıq
        var accessToken = _jwtGenerator.GenerateAccessToken(user, roles);

        // 5. Yeni bir Refresh Token yaradırıq (Rotation - hər dəfə yenisi verilir)
        var newRefreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user);

        // 6. Yeni paketimizi qaytarırıq
        return Result<TokenResponse>.Success(new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            Expiration = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes)
        });
    }

    public async Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request, CancellationToken ct = default)
    {
        // 1. ID-yə görə istifadəçini tapırıq
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return Result.Failure("İstifadəçi tapılmadı.");

        // 2. Identity mexanizmini çağıraraq tokeni yoxlayırıq və təsdiqləyirik
        var result = await _userManager.ConfirmEmailAsync(user, request.Token);

        // 3. Əgər Identity xəta verərsə (məs: token səhvdirsə)
        if (!result.Succeeded)
            return Result.Failure("Təsdiqləmə linki yanlışdır və ya vaxtı bitib.");

        return Result.Success();
    }

}
