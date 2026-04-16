using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.RolePermission.DeleteRolePermission;

public sealed class DeleteRolePermissionCommandHandler : IRequestHandler<DeleteRolePermissionCommandRequest, Result>
{
    public Task<Result> Handle(DeleteRolePermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
