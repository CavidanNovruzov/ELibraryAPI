using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PaymentMethod.GetByIdPaymentMethod;

public sealed class GetByIdPaymentMethodQueryHandler : IRequestHandler<GetByIdPaymentMethodQueryRequest, Result<GetByIdPaymentMethodQueryResponse>>
{
    public Task<Result<GetByIdPaymentMethodQueryResponse>> Handle(GetByIdPaymentMethodQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
