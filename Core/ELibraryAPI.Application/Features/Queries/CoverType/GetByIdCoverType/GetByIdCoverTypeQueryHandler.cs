using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.CoverType.GetByIdCoverType;

public sealed class GetByIdCoverTypeQueryHandler : IRequestHandler<GetByIdCoverTypeQueryRequest, Result<GetByIdCoverTypeQueryResponse>>
{
    public Task<Result<GetByIdCoverTypeQueryResponse>> Handle(GetByIdCoverTypeQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
