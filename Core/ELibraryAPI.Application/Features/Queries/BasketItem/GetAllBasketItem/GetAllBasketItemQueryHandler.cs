using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BasketItem.GetAllBasketItem;

public sealed class GetAllBasketItemQueryHandler : IRequestHandler<GetAllBasketItemQueryRequest, Result<GetAllBasketItemQueryResponse>>
{
    public Task<Result<GetAllBasketItemQueryResponse>> Handle(GetAllBasketItemQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
