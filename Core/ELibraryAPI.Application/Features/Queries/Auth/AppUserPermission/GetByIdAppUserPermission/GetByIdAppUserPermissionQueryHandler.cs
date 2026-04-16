using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.AppUserPermission.GetByIdAppUserPermission;

public sealed class GetByIdAppUserPermissionQueryHandler : IRequestHandler<GetByIdAppUserPermissionQueryRequest, Result<GetByIdAppUserPermissionQueryResponse>>
{
    public Task<Result<GetByIdAppUserPermissionQueryResponse>> Handle(GetByIdAppUserPermissionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
