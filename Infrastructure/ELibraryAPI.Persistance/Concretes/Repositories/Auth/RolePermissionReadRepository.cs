using ELibraryAPI.Application.Abstractions.Repositories.Auth;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Persistance.Concrete.Repositories;
using ELibraryAPI.Persistence.Contexts;

namespace ELibraryAPI.Persistance.Concrete.Repositories.Auth;

public class RolePermissionReadRepository : ReadRepository<RolePermission, Guid>, IRolePermissionReadRepository
{
    public RolePermissionReadRepository(ELibraryDbContext context) : base(context)
    {
    }
}
