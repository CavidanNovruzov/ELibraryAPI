using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ShippingMethod.DeleteShippingMethod;

public sealed class DeleteShippingMethodCommandHandler : IRequestHandler<DeleteShippingMethodCommandRequest, Result>
{
    public Task<Result> Handle(DeleteShippingMethodCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
