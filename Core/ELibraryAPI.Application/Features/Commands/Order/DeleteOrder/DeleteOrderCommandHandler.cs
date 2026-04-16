using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Order.DeleteOrder;

public sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, Result>
{
    public Task<Result> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
