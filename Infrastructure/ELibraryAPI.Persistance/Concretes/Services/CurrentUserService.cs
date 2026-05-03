
using ELibraryAPI.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ELibraryAPI.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public Guid UserGuid
    {
        get
        {
            var userId = UserId;
            return Guid.TryParse(userId, out var guid) ? guid : Guid.Empty;
        }
    }

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
}