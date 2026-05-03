namespace ELibraryAPI.Application.Features.Queries.Order.GetAllOrder;

public sealed record GetAllOrderQueryResponse(
    List<OrderListDto> Orders
);

public sealed record OrderListDto(
    Guid Id,
    string OrderNumber,
    DateTime CreatedDate,
    decimal TotalAmount,
    string OrderStatusName,
    string UserEmail,
    int ItemCount
);
