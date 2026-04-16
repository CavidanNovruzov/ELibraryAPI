using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BasketItem.GetByIdBasketItem;

public sealed record GetByIdBasketItemQueryRequest(Guid Id) : IRequest<Result<GetByIdBasketItemQueryResponse>>;
