using ELibraryAPI.Domain.Entities.Common;
using System.Security.Principal;

namespace ELibraryAPI.Domain.Entities.Concrete.Auth;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; }
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public Guid UserId { get; set; }
    public AppUser User { get; set; }
    public string TokenHash { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime? RevokedAt { get; set; }
    public string? ReplacedByTokenHash { get; set; }
    public string? CreatedByIp { get; set; }
    public string? RevokedByIp { get; set; }
}
