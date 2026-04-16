using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Domain.Entities.Concrete.Auth
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
