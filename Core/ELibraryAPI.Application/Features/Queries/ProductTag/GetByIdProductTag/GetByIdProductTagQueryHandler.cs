using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductTag.GetByIdProductTag;

public sealed class GetByIdProductTagQueryHandler : IRequestHandler<GetByIdProductTagQueryRequest, Result<GetByIdProductTagQueryResponse>>
{
    public Task<Result<GetByIdProductTagQueryResponse>> Handle(GetByIdProductTagQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
