using ELibraryAPI.Application.UnitOfWork;
using ELibraryAPI.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Commands.Auth.Roles.RolePermission;

public class SetRolePermissionsCommandHandler : IRequestHandler<SetRolePermissionsCommandRequest, Result>
{
    private readonly IUnitOfWork _uow;

    public SetRolePermissionsCommandHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Result> Handle(SetRolePermissionsCommandRequest request, CancellationToken ct)
    {
        // Instansiya adı "Repository" ilə bitməlidir
        var rolePermissionRepository = _uow.WriteRepository<Domain.Entities.Concrete.Auth.RolePermission, Guid>();

        // Köhnə icazələri gətiririk
        var existing = await rolePermissionRepository.Table
            .Where(rp => rp.RoleId == request.RoleId)
            .ToListAsync(ct);

        // Köhnələri silirik
        if (existing.Any())
            rolePermissionRepository.RemoveRange(existing);

        // Yeni icazə siyahısını yaradırıq
        var newPermissions = request.PermissionIds.Select(pId => new Domain.Entities.Concrete.Auth.RolePermission
        {
            RoleId = request.RoleId,
            PermissionId = pId
        }).ToList();

        await rolePermissionRepository.AddRangeAsync(newPermissions);

        var result = await _uow.SaveAsync(ct) > 0;

        if (result)
            return Result.Success("Role permissions updated successfully.");

        return Result.Failure("No changes were made or an error occurred.");
    }
}