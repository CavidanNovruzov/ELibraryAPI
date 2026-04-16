using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Permission.GetByIdPermission;

public sealed class GetByIdPermissionQueryHandler : IRequestHandler<GetByIdPermissionQueryRequest, Result<GetByIdPermissionQueryResponse>>
{
    public Task<Result<GetByIdPermissionQueryResponse>> Handle(GetByIdPermissionQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
