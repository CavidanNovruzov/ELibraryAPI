using ELibraryAPI.Application.Options;
using ELibraryAPI.Domain.Constants;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ELibraryAPI.Persistance.Data;

public static class AdminSeeder
{
    public static async Task SeedAdminAsync(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        ELibraryDbContext context, 
        IOptions<SeedOptions> seedOptions)
    {
        var seed = seedOptions.Value.Admin;
        if (string.IsNullOrWhiteSpace(seed.AdminEmail)) return;

        string[] roles = { RoleNames.Admin, RoleNames.User };
        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new AppRole { Name = roleName });
            }
        }

        var adminRole = await roleManager.FindByNameAsync(RoleNames.Admin);
        if (adminRole != null)
        {
            var allPermissionIds = await context.Permissions.Select(p => p.Id).ToListAsync();

            var existingRolePermissionIds = await context.RolePermissions
                .Where(rp => rp.RoleId == adminRole.Id)
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            var permissionsToAssign = allPermissionIds
                .Except(existingRolePermissionIds)
                .Select(pId => new RolePermission
                {
                    RoleId = adminRole.Id,
                    PermissionId = pId
                }).ToList();

            if (permissionsToAssign.Any())
            {
                await context.RolePermissions.AddRangeAsync(permissionsToAssign);
                await context.SaveChangesAsync();
            }
        }

        var adminUser = await userManager.FindByEmailAsync(seed.AdminEmail);
        if (adminUser == null)
        {
            adminUser = new AppUser
            {
                UserName = seed.AdminEmail.Split('@')[0],
                Email = seed.AdminEmail,
                FirstName = seed.AdminFullName,
                LastName = "System",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, seed.AdminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, RoleNames.Admin);
            }
        }
    }
}