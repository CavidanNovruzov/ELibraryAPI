using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete.Auth;

public class RefreshToken : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual AppUser User { get; set; } = null!;

    public string TokenHash { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }

    // Tokenin hələ də keçərli olub-olmadığını yoxlamaq üçün
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

    public bool IsRevoked { get; set; }
    public DateTime? RevokedAt { get; set; }
    public string? ReplacedByTokenHash { get; set; }
    public string? CreatedByIp { get; set; }
    public string? RevokedByIp { get; set; }

    // Token həm ləğv edilməyibsə, həm də vaxtı bitməyibsə aktivdir
    public bool IsActive => !IsRevoked && !IsExpired;
}