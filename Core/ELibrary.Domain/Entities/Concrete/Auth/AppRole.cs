using ELibraryAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace ELibraryAPI.Domain.Entities.Concrete.Auth;

public class AppRole : IdentityRole<Guid>, IEntity<Guid>, IAuditEntity, ISoftDelete
{
    public AppRole() : base()
    {
        RolePermissions = new HashSet<RolePermission>();
    }

    public AppRole(string roleName) : base(roleName)
    {
        RolePermissions = new HashSet<RolePermission>();
    }
    public virtual ICollection<RolePermission> RolePermissions { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string CreatedBy { get; set; } = "System";
    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
}