using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ShippingMethod.CreateShippingMethod;

public sealed class CreateShippingMethodCommandHandler : IRequestHandler<CreateShippingMethodCommandRequest, Result<CreateShippingMethodCommandResponse>>
{
    public Task<Result<CreateShippingMethodCommandResponse>> Handle(CreateShippingMethodCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
