namespace ELibraryAPI.Application.Features.Queries.OrderStatus.GetAllOrderStatus;

public sealed record GetAllOrderStatusQueryResponse(
    List<OrderStatusListDto> OrderStatuses
);

public sealed record OrderStatusListDto(
    Guid Id,
    string Name
);
