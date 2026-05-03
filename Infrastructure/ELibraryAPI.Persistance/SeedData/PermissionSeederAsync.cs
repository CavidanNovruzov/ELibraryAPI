using ELibraryAPI.Domain.Constants;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ELibraryAPI.Persistance.Data;

public static class PermissionSeeder
{
    public static async Task SeedPermissionsAsync(ELibraryDbContext context)
    {
        // 1. AuthorizePermissions daxilindəki bütün sabit stringləri (Key) Reflection ilə tapırıq
        var permissionKeys = typeof(AuthorizePermissions)
            .GetNestedTypes()
            .SelectMany(t => t.GetFields(BindingFlags.Public | BindingFlags.Static))
            .Select(f => f.GetValue(null)?.ToString())
            .Where(v => v != null)
            .Distinct()
            .ToList();

        // 2. Performans üçün bazadakı mövcud icazələri bir dəfəyə yaddaşa çəkirik
        var existingPermissions = await context.Permissions
            .Select(p => p.Key)
            .ToListAsync();

        var newPermissions = new List<Permission>();

        foreach (var key in permissionKeys)
        {
            // 3. Əgər yaddaşdakı siyahıda bu key yoxdursa, yeni siyahıya əlavə edirik
            if (!existingPermissions.Contains(key!))
            {
                newPermissions.Add(new Permission
                {
                    Key = key!,
                    IsDelegatable = true,
                    CreatedDate = DateTime.UtcNow
                });
            }
        }

        // 4. Əgər yeni icazələr tapılıbsa, hamısını birdən əlavə edib yadda saxlayırıq
        if (newPermissions.Count != 0)
        {
            await context.Permissions.AddRangeAsync(newPermissions);
            await context.SaveChangesAsync();
        }
    }
}