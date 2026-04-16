using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Branch.GetByIdBranch;

public sealed class GetByIdBranchQueryHandler : IRequestHandler<GetByIdBranchQueryRequest, Result<GetByIdBranchQueryResponse>>
{
    public Task<Result<GetByIdBranchQueryResponse>> Handle(GetByIdBranchQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
