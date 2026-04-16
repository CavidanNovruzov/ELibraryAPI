using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Permission.DeletePermission;

public sealed class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommandRequest, Result>
{
    public Task<Result> Handle(DeletePermissionCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
