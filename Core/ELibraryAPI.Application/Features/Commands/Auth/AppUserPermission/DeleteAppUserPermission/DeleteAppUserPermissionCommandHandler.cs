using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.AppUserPermission.DeleteAppUserPermission;

public sealed class DeleteAppUserPermissionCommandHandler : IRequestHandler<DeleteAppUserPermissionCommandRequest, Result>
{
    public Task<Result> Handle(DeleteAppUserPermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
