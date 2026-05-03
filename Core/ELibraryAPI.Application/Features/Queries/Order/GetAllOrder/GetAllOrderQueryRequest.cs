using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Order.GetAllOrder;

public sealed record GetAllOrderQueryRequest : IRequest<Result<GetAllOrderQueryResponse>>;
