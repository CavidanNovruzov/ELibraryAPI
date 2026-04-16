using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderItem.GetByIdOrderItem;

public sealed record GetByIdOrderItemQueryRequest(Guid Id) : IRequest<Result<GetByIdOrderItemQueryResponse>>;
