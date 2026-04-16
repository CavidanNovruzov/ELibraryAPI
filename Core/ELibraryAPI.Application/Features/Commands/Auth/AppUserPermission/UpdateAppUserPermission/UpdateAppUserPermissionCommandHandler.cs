using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.AppUserPermission.UpdateAppUserPermission;

public sealed class UpdateAppUserPermissionCommandHandler : IRequestHandler<UpdateAppUserPermissionCommandRequest, Result<UpdateAppUserPermissionCommandResponse>>
{
    public Task<Result<UpdateAppUserPermissionCommandResponse>> Handle(UpdateAppUserPermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
