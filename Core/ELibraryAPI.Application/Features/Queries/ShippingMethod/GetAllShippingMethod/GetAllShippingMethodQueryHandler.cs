using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ShippingMethod.GetAllShippingMethod;

public sealed class GetAllShippingMethodQueryHandler : IRequestHandler<GetAllShippingMethodQueryRequest, Result<GetAllShippingMethodQueryResponse>>
{
    public Task<Result<GetAllShippingMethodQueryResponse>> Handle(GetAllShippingMethodQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
