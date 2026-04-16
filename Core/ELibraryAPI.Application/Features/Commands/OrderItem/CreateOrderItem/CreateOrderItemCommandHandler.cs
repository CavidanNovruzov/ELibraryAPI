using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.CreateOrderItem;

public sealed class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommandRequest, Result<CreateOrderItemCommandResponse>>
{
    public Task<Result<CreateOrderItemCommandResponse>> Handle(CreateOrderItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
