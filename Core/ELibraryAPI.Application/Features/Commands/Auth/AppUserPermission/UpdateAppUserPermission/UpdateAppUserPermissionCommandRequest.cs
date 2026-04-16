using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.AppUserPermission.UpdateAppUserPermission;

public sealed record UpdateAppUserPermissionCommandRequest(
    Guid Id,
    int PermissionId,
    Guid UserId
) : IRequest<Result<UpdateAppUserPermissionCommandResponse>>;
