using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderStatus.UpdateOrderStatus;

public sealed class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommandRequest, Result<UpdateOrderStatusCommandResponse>>
{
    public Task<Result<UpdateOrderStatusCommandResponse>> Handle(UpdateOrderStatusCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
