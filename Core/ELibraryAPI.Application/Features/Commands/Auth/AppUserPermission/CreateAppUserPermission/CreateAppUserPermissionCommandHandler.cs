using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.AppUserPermission.CreateAppUserPermission;

public sealed class CreateAppUserPermissionCommandHandler : IRequestHandler<CreateAppUserPermissionCommandRequest, Result<CreateAppUserPermissionCommandResponse>>
{
    public Task<Result<CreateAppUserPermissionCommandResponse>> Handle(CreateAppUserPermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
