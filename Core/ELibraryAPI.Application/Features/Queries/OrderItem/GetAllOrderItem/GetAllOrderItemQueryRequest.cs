using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderItem.GetAllOrderItem;

public sealed record GetAllOrderItemQueryRequest : IRequest<Result<GetAllOrderItemQueryResponse>>;
