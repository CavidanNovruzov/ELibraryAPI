using ELibraryAPI.Application.Options;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Persistance.Data;
using ELibraryAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ELibraryAPI.API.Extensions;

public static class DbSeedExtension
{
    public static async Task SeedDataAsync(this WebApplication app)
    {
        // 1. Servislərə müraciət etmək üçün scope yaradırıq
        using var scope = app.Services.CreateScope();

        // 2. Lazımi servisləri əldə edirik
        // QEYD: ELibraryDbContext hissəsini öz real DbContext adınızla əvəz edin
        var context = scope.ServiceProvider.GetRequiredService<ELibraryDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
        var seedOptions = scope.ServiceProvider.GetRequiredService<IOptions<SeedOptions>>();

        try
        {
            // 3. Əvvəlcə icazələri bazaya yazırıq (PermissionSeeder)
            await PermissionSeeder.SeedPermissionsAsync(context);

            // 4. Sonra Admin istifadəçisini və rolunu yaradırıq (AdminSeeder)
            await AdminSeeder.SeedAdminAsync(userManager, roleManager, context, seedOptions);
        }
        catch (Exception ex)
        {
            // Xəta olarsa loqlamaq olar
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}