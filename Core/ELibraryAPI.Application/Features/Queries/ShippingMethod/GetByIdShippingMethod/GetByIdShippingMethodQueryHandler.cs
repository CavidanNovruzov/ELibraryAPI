using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ShippingMethod.GetByIdShippingMethod;

public sealed class GetByIdShippingMethodQueryHandler : IRequestHandler<GetByIdShippingMethodQueryRequest, Result<GetByIdShippingMethodQueryResponse>>
{
    public Task<Result<GetByIdShippingMethodQueryResponse>> Handle(GetByIdShippingMethodQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
