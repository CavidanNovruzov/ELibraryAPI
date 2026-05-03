namespace ELibraryAPI.Application.Features.Queries.Basket.GetByIdBasket;

public sealed record GetByIdBasketQueryResponse(
    BasketDetailDto Basket
);

public sealed record BasketDetailDto(
    Guid Id,
    decimal TotalPrice,
    List<BasketItemDetailDto> Items
);

public sealed record BasketItemDetailDto(
    Guid Id,
    Guid ProductId,
    string ProductTitle,
    string ImageUrl,
    decimal ProductPrice,
    int Quantity,
    decimal LineTotal
);
