using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductImage.GetByIdProductImage;

public sealed class GetByIdProductImageQueryHandler : IRequestHandler<GetByIdProductImageQueryRequest, Result<GetByIdProductImageQueryResponse>>
{
    public Task<Result<GetByIdProductImageQueryResponse>> Handle(GetByIdProductImageQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
