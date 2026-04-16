using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RolePermission.DeleteRolePermission;

public sealed record DeleteRolePermissionCommandRequest(Guid Id) : IRequest<Result>;
