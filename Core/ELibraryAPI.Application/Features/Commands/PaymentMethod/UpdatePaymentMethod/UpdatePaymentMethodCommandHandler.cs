using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PaymentMethod.UpdatePaymentMethod;

public sealed class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommandRequest, Result<UpdatePaymentMethodCommandResponse>>
{
    public Task<Result<UpdatePaymentMethodCommandResponse>> Handle(UpdatePaymentMethodCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
