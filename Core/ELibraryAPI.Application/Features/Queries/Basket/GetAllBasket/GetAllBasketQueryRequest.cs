using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Basket.GetAllBasket;

public sealed record GetAllBasketQueryRequest : IRequest<Result<GetAllBasketQueryResponse>>;
