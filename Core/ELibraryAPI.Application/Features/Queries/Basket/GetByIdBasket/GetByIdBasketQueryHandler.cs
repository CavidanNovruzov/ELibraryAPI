using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Basket.GetByIdBasket;

public sealed class GetByIdBasketQueryHandler : IRequestHandler<GetByIdBasketQueryRequest, Result<GetByIdBasketQueryResponse>>
{
    public Task<Result<GetByIdBasketQueryResponse>> Handle(GetByIdBasketQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
