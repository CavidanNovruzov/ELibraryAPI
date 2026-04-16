using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.DeleteBasket;

public sealed class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, Result>
{
    public Task<Result> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
