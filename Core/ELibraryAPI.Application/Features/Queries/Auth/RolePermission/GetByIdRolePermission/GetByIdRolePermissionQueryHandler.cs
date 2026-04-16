using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.RolePermission.GetByIdRolePermission;

public sealed class GetByIdRolePermissionQueryHandler : IRequestHandler<GetByIdRolePermissionQueryRequest, Result<GetByIdRolePermissionQueryResponse>>
{
    public Task<Result<GetByIdRolePermissionQueryResponse>> Handle(GetByIdRolePermissionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
