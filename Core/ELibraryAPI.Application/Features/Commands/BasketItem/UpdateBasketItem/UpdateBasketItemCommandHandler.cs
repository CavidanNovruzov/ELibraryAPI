using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.UpdateBasketItem;

public sealed class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, Result<UpdateBasketItemCommandResponse>>
{
    public Task<Result<UpdateBasketItemCommandResponse>> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
