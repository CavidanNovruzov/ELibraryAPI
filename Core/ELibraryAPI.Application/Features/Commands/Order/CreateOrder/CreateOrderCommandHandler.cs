using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Order.CreateOrder;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, Result<CreateOrderCommandResponse>>
{
    public Task<Result<CreateOrderCommandResponse>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
