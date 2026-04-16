using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.DeleteOrderItem;

public sealed class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommandRequest, Result>
{
    public Task<Result> Handle(DeleteOrderItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
