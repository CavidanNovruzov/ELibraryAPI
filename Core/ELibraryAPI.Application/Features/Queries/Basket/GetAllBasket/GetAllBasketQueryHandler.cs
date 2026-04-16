using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Basket.GetAllBasket;

public sealed class GetAllBasketQueryHandler : IRequestHandler<GetAllBasketQueryRequest, Result<GetAllBasketQueryResponse>>
{
    public Task<Result<GetAllBasketQueryResponse>> Handle(GetAllBasketQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
