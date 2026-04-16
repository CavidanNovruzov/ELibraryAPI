using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.CreateBasket;

public sealed class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, Result<CreateBasketCommandResponse>>
{
    public Task<Result<CreateBasketCommandResponse>> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
