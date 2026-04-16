using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.UpdateOrderItem;

public sealed class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommandRequest, Result<UpdateOrderItemCommandResponse>>
{
    public Task<Result<UpdateOrderItemCommandResponse>> Handle(UpdateOrderItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
