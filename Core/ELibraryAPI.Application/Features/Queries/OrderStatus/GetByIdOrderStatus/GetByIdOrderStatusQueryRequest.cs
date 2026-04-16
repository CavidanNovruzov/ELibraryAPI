using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderStatus.GetByIdOrderStatus;

public sealed record GetByIdOrderStatusQueryRequest(Guid Id) : IRequest<Result<GetByIdOrderStatusQueryResponse>>;
