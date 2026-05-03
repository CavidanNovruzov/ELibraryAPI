using ELibraryAPI.Application.Abstractions.Services;
using ELibraryAPI.Application.Abstractions.Services.Auth;
using ELibraryAPI.Application.Abstractions.Services.Storage;
using ELibraryAPI.Application.Options;
using ELibraryAPI.Infrastructure.Options;
using ELibraryAPI.Infrastructure.Security.Authorization;
using ELibraryAPI.Infrastructure.Services;
using ELibraryAPI.Infrastructure.Services.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ELibraryAPI.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        services.Configure<SmtpOptions>(configuration.GetSection(SmtpOptions.SectionName));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IEmailSender, SmtpEmailSender>();
        services.AddScoped<IStorageService, LocalStorage>();

        // 1. Dinamik Policy Provider qeydiyyatı
        // Bu sinif [HasPermission("...")] gördükdə avtomatik policy yaradır.
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

        // 2. Permission Handler qeydiyyatı (Scoped)
        // Bu sinif istifadəçinin icazələrini həqiqətən yoxlayan məntiqi saxlayır.
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
    }
}
