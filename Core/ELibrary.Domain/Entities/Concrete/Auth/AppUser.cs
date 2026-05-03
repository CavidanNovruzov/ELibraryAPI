using ELibraryAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace ELibraryAPI.Domain.Entities.Concrete.Auth;

public class AppUser : IdentityUser<Guid>, IEntity<Guid>, IAuditEntity, ISoftDelete
{
    public AppUser() : base()
    {
        RefreshTokens = new HashSet<RefreshToken>();
        Orders = new HashSet<Order>();
        Reviews = new HashSet<Review>();
        Addresses = new HashSet<UserAddress>();
        SearchHistories = new HashSet<UserSearchHistory>();
        UserPermissions = new HashSet<AppUserPermission>();
        GrantedPermissions = new HashSet<AppUserPermission>();
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    // Navigation Properties - Virtual olması Lazy Loading üçün vacibdir
    public virtual Basket? Basket { get; set; }
    public virtual Wishlist? Wishlist { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string CreatedBy { get; set; } = "System";
    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<UserAddress> Addresses { get; set; }
    public virtual ICollection<UserSearchHistory> SearchHistories { get; set; }
    public virtual ICollection<AppUserPermission> UserPermissions { get; set; }
    public virtual ICollection<AppUserPermission> GrantedPermissions { get; set; }
}