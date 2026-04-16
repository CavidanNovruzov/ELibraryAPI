using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RolePermission.CreateRolePermission;

public sealed record CreateRolePermissionCommandRequest(
    int PermissionId,
    string RoleId
) : IRequest<Result<CreateRolePermissionCommandResponse>>;
