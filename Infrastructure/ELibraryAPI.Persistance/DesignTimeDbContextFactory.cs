
using ELibraryAPI.Application.Abstractions.Services;
using ELibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ELibraryAPI.Persistance;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ELibraryDbContext>
{
    public ELibraryDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ELibraryDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);

        var mockCurrentUserService = new DesignTimeCurrentUserService();

        return new ELibraryDbContext(dbContextOptionsBuilder.Options, mockCurrentUserService);
    }
}

public class DesignTimeCurrentUserService : ICurrentUserService
{
    public string? UserId => "Migration-System";

    public Guid UserGuid => Guid.Empty;

    public bool IsAuthenticated => true;
}