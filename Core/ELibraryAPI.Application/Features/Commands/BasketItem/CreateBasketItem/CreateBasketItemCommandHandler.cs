using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.CreateBasketItem;

public sealed class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest, Result<CreateBasketItemCommandResponse>>
{
    public Task<Result<CreateBasketItemCommandResponse>> Handle(CreateBasketItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
