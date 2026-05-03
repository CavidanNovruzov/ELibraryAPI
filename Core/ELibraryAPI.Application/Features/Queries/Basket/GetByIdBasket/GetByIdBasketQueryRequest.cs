using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Basket.GetByIdBasket;

public sealed record GetByIdBasketQueryRequest(Guid Id) : IRequest<Result<GetByIdBasketQueryResponse>>;
