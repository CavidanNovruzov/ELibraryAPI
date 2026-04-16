using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BasketItem.GetByIdBasketItem;

public sealed class GetByIdBasketItemQueryHandler : IRequestHandler<GetByIdBasketItemQueryRequest, Result<GetByIdBasketItemQueryResponse>>
{
    public Task<Result<GetByIdBasketItemQueryResponse>> Handle(GetByIdBasketItemQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
