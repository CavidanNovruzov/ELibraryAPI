using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.DeleteBasketItem;

public sealed class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, Result>
{
    public Task<Result> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
