using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Order.UpdateOrder;

public sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, Result<UpdateOrderCommandResponse>>
{
    public Task<Result<UpdateOrderCommandResponse>> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
