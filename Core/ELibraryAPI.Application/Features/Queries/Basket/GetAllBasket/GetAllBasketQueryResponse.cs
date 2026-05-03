namespace ELibraryAPI.Application.Features.Queries.Basket.GetAllBasket;

public sealed record GetAllBasketQueryResponse(
    List<BasketListDto> Baskets
);

public sealed record BasketListDto(
    Guid Id,
    Guid UserId,
    string UserEmail,
    decimal TotalPrice,
    int ItemCount
);
