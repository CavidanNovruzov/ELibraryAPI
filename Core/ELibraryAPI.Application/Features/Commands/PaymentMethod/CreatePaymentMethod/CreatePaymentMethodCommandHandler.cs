using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PaymentMethod.CreatePaymentMethod;

public sealed class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommandRequest, Result<CreatePaymentMethodCommandResponse>>
{
    public Task<Result<CreatePaymentMethodCommandResponse>> Handle(CreatePaymentMethodCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
