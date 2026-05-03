using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;


namespace ELibraryAPI.Infrastructure.Security.Authorization;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _scopeFactory;
    public PermissionHandler(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        // Token-dən gələn bütün permission claim-lərini oxuyuruq
        var permissions = context.User.FindAll("permission").Select(x => x.Value);

        if (permissions.Any(p => p == requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}