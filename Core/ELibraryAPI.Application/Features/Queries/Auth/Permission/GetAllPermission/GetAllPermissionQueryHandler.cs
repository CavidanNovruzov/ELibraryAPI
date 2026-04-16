using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Permission.GetAllPermission;

public sealed class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQueryRequest, Result<GetAllPermissionQueryResponse>>
{
    public Task<Result<GetAllPermissionQueryResponse>> Handle(GetAllPermissionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
