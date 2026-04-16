using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RolePermission.CreateRolePermission;

public sealed class CreateRolePermissionCommandHandler : IRequestHandler<CreateRolePermissionCommandRequest, Result<CreateRolePermissionCommandResponse>>
{
    public Task<Result<CreateRolePermissionCommandResponse>> Handle(CreateRolePermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
