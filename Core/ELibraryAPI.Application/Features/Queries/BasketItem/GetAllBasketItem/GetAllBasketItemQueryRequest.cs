using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BasketItem.GetAllBasketItem;

public sealed record GetAllBasketItemQueryRequest : IRequest<Result<GetAllBasketItemQueryResponse>>;
