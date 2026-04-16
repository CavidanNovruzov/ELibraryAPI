using ELibraryAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace ELibraryAPI.Domain.Entities.Concrete.Auth;

public class RolePermission:BaseEntity
{
    public string RoleId { get; set; } = null!;
    public IdentityRole Role { get; set; } = null!;
    public int PermissionId { get; set; }
    public Permission Permission { get; set; } = null!;

}
