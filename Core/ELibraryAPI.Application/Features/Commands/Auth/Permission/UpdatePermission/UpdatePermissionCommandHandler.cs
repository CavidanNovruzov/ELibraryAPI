using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Permission.UpdatePermission;

public sealed class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommandRequest, Result<UpdatePermissionCommandResponse>>
{
    public Task<Result<UpdatePermissionCommandResponse>> Handle(UpdatePermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
