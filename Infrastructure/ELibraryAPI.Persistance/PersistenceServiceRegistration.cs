using ELibraryAPI.Application.Abstractions.Repositories;
using ELibraryAPI.Application.Abstractions.Repositories.Auth;
using ELibraryAPI.Application.Abstractions.Repositories.Entities;
using ELibraryAPI.Application.Abstractions.Services.Auth;
using ELibraryAPI.Application.UnitOfWork;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Persistance.Concrete.Repositories.Entities;
using ELibraryAPI.Persistance.Concrete.Repositories;
using ELibraryAPI.Persistance.Concrete.Repositories.Auth;
using ELibraryAPI.Persistance.Concretes.Services;
using ELibraryAPI.Persistence.Contexts;
using ELibraryAPI.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ELibraryAPI.Persistance;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<ELibraryDbContext>(options =>
            options.UseSqlServer(Configuration.ConnectionString));

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<ELibraryDbContext>();

        // 1. Generic Repository-lərin qeydiyyatı (Open Generics)
        services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
        services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));

        // 2. Spesifik (Custom) Repository-lərin qeydiyyatı
        services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
        services.AddScoped<IRefreshTokenWriteRepository, RefreshTokenWriteRepository>();

        services.AddScoped<IPermissionReadRepository, PermissionReadRepository>();
        services.AddScoped<IPermissionWriteRepository, PermissionWriteRepository>();
        services.AddScoped<IRolePermissionReadRepository, RolePermissionReadRepository>();
        services.AddScoped<IRolePermissionWriteRepository, RolePermissionWriteRepository>();
        services.AddScoped<IUserPermissionReadRepository, UserPermissionReadRepository>();
        services.AddScoped<IUserPermissionWriteRepository, UserPermissionWriteRepository>();

        // Entity-specific repositories are intentionally omitted here because the project
        // uses a dynamic UnitOfWork + open-generic repositories for most entities.
        //
        // If you ever need to override behavior for a specific entity, register ONLY that custom repo here.
        //
        // services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
        // services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
        // ...

        // Domain services implemented in Persistence
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}

