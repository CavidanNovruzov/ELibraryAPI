using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderStatus.GetAllOrderStatus;

public sealed record GetAllOrderStatusQueryRequest : IRequest<Result<GetAllOrderStatusQueryResponse>>;
