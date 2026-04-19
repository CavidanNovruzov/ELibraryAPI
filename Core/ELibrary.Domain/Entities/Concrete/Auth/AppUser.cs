using ELibraryAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;


namespace ELibraryAPI.Domain.Entities.Concrete.Auth;

public class AppUser : IdentityUser<Guid>,IEntity<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public Basket? Basket { get; set; }
    public Wishlist? Wishlist { get; set; }


    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
    public ICollection<UserSearchHistory> SearchHistories { get; set; } = new List<UserSearchHistory>();
    public ICollection<AppUserPermission> UserPermissions { get; set; } = new List<AppUserPermission>();
    public ICollection<AppUserPermission> GrantedPermissions { get; set; } = new List<AppUserPermission>();
}