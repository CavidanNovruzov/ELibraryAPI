using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Product.GetAllProduct;

public sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, Result<GetAllProductQueryResponse>>
{
    public Task<Result<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
