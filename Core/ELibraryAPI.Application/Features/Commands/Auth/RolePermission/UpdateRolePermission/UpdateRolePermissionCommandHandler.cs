using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RolePermission.UpdateRolePermission;

public sealed class UpdateRolePermissionCommandHandler : IRequestHandler<UpdateRolePermissionCommandRequest, Result<UpdateRolePermissionCommandResponse>>
{
    public Task<Result<UpdateRolePermissionCommandResponse>> Handle(UpdateRolePermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
