using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete.Auth;

public class Permission : BaseEntity<int>
{
    public string Key { get; set; } = null!;
    public ICollection<AppUserPermission> UserPermissions { get; set; } = new List<AppUserPermission>();
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public bool IsDelegatable { get; set; } = true;
}
