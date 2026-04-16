using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductImage.GetAllProductImage;

public sealed class GetAllProductImageQueryHandler : IRequestHandler<GetAllProductImageQueryRequest, Result<GetAllProductImageQueryResponse>>
{
    public Task<Result<GetAllProductImageQueryResponse>> Handle(GetAllProductImageQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
