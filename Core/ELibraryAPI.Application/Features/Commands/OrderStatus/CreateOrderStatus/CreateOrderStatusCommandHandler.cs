using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderStatus.CreateOrderStatus;

public sealed class CreateOrderStatusCommandHandler : IRequestHandler<CreateOrderStatusCommandRequest, Result<CreateOrderStatusCommandResponse>>
{
    public Task<Result<CreateOrderStatusCommandResponse>> Handle(CreateOrderStatusCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
