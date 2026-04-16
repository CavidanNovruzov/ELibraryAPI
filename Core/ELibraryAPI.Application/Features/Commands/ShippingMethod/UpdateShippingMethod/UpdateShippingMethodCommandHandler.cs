using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ShippingMethod.UpdateShippingMethod;

public sealed class UpdateShippingMethodCommandHandler : IRequestHandler<UpdateShippingMethodCommandRequest, Result<UpdateShippingMethodCommandResponse>>
{
    public Task<Result<UpdateShippingMethodCommandResponse>> Handle(UpdateShippingMethodCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
