using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.UpdateBasket;

public sealed class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, Result<UpdateBasketCommandResponse>>
{
    public Task<Result<UpdateBasketCommandResponse>> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
