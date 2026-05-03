namespace ELibraryAPI.Application.Features.Queries.ShippingMethod.GetAllShippingMethod;

public sealed record GetAllShippingMethodQueryResponse(
    List<ShippingMethodListDto> ShippingMethods
);

public sealed record ShippingMethodListDto(
    Guid Id,
    string Name,
    decimal Price
);
