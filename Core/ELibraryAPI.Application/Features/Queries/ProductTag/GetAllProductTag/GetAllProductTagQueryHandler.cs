using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductTag.GetAllProductTag;

public sealed class GetAllProductTagQueryHandler : IRequestHandler<GetAllProductTagQueryRequest, Result<GetAllProductTagQueryResponse>>
{
    public Task<Result<GetAllProductTagQueryResponse>> Handle(GetAllProductTagQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
