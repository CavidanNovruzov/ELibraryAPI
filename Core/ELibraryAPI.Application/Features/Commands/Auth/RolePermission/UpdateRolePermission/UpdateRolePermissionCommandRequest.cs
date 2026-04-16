using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RolePermission.UpdateRolePermission;

public sealed record UpdateRolePermissionCommandRequest(
    Guid Id,
    int PermissionId,
    string RoleId
) : IRequest<Result<UpdateRolePermissionCommandResponse>>;
