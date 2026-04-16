using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Permission.UpdatePermission;

public sealed record UpdatePermissionCommandRequest(
    Guid Id,
    string Key
) : IRequest<Result<UpdatePermissionCommandResponse>>;
