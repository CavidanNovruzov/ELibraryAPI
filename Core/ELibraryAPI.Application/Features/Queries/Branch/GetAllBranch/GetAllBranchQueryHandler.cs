using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Branch.GetAllBranch;

public sealed class GetAllBranchQueryHandler : IRequestHandler<GetAllBranchQueryRequest, Result<GetAllBranchQueryResponse>>
{
    public Task<Result<GetAllBranchQueryResponse>> Handle(GetAllBranchQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
