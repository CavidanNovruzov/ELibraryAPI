using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderStatus.DeleteOrderStatus;

public sealed class DeleteOrderStatusCommandHandler : IRequestHandler<DeleteOrderStatusCommandRequest, Result>
{
    public Task<Result> Handle(DeleteOrderStatusCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
