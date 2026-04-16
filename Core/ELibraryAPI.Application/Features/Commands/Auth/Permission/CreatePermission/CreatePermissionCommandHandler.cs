using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Permission.CreatePermission;

public sealed class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommandRequest, Result<CreatePermissionCommandResponse>>
{
    public Task<Result<CreatePermissionCommandResponse>> Handle(CreatePermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
