using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.CoverType.GetAllCoverType;

public sealed class GetAllCoverTypeQueryHandler : IRequestHandler<GetAllCoverTypeQueryRequest, Result<GetAllCoverTypeQueryResponse>>
{
    public Task<Result<GetAllCoverTypeQueryResponse>> Handle(GetAllCoverTypeQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
