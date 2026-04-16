using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.AppUserPermission.GetAllAppUserPermission;

public sealed class GetAllAppUserPermissionQueryHandler : IRequestHandler<GetAllAppUserPermissionQueryRequest, Result<GetAllAppUserPermissionQueryResponse>>
{
    public Task<Result<GetAllAppUserPermissionQueryResponse>> Handle(GetAllAppUserPermissionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
