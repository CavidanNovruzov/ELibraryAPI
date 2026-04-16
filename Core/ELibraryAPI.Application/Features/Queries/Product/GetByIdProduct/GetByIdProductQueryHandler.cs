using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Product.GetByIdProduct;

public sealed class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, Result<GetByIdProductQueryResponse>>
{
    public Task<Result<GetByIdProductQueryResponse>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
