using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.RolePermission.GetAllRolePermission;

public sealed class GetAllRolePermissionQueryHandler : IRequestHandler<GetAllRolePermissionQueryRequest, Result<GetAllRolePermissionQueryResponse>>
{
    public Task<Result<GetAllRolePermissionQueryResponse>> Handle(GetAllRolePermissionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
