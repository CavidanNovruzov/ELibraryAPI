using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PaymentMethod.GetAllPaymentMethod;

public sealed class GetAllPaymentMethodQueryHandler : IRequestHandler<GetAllPaymentMethodQueryRequest, Result<GetAllPaymentMethodQueryResponse>>
{
    public Task<Result<GetAllPaymentMethodQueryResponse>> Handle(GetAllPaymentMethodQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
