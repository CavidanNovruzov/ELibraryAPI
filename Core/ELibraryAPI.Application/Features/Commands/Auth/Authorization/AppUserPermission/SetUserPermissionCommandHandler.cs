using ELibraryAPI.Application.UnitOfWork;
using ELibraryAPI.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Commands.Auth.Roles.AppUserPermission;

public class SetUserPermissionCommandHandler : IRequestHandler<SetUserPermissionCommandRequest, Result>
{
    private readonly IUnitOfWork _uow;

    public SetUserPermissionCommandHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Result> Handle(SetUserPermissionCommandRequest request, CancellationToken ct)
    {
        // Instansiya adı mütləq "Repository" ilə bitməlidir
        var userPermissionRepository = _uow.WriteRepository<Domain.Entities.Concrete.Auth.AppUserPermission, Guid>();

        // 1. İstifadəçinin hazırkı xüsusi icazələrini tap
        var existing = await userPermissionRepository.Table
            .Where(up => up.UserId == request.UserId)
            .ToListAsync(ct);

        // 2. Köhnələri sil
        if (existing.Count > 0)
            userPermissionRepository.RemoveRange(existing);

        // 3. Yeni siyahını yarat
        var newPermissions = request.PermissionIds.Select(pId => new Domain.Entities.Concrete.Auth.AppUserPermission
        {
            UserId = request.UserId,
            PermissionId = pId
        }).ToList();

        await userPermissionRepository.AddRangeAsync(newPermissions);

        // 4. Bazaya yaz və nəticəni Result tipində qaytar
        var saveResult = await _uow.SaveAsync(ct) > 0;

        if (saveResult)
            return Result.Success("User permissions updated successfully.");

        return Result.Failure("No changes were made or an error occurred.");
    }
}