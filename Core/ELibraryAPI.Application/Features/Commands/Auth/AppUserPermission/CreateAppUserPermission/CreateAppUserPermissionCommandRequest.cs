using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.AppUserPermission.CreateAppUserPermission;

public sealed record CreateAppUserPermissionCommandRequest(
    int PermissionId,
    Guid UserId
) : IRequest<Result<CreateAppUserPermissionCommandResponse>>;
