using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PaymentMethod.DeletePaymentMethod;

public sealed class DeletePaymentMethodCommandHandler : IRequestHandler<DeletePaymentMethodCommandRequest, Result>
{
    public Task<Result> Handle(DeletePaymentMethodCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
