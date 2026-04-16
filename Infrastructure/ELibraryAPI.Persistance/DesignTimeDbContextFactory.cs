using ELibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Persistance;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ELibraryDbContext>
{
    public ELibraryDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ELibraryDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}
