using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ShippingMethod.GetByIdShippingMethod;

public sealed record GetByIdShippingMethodQueryRequest(Guid Id) : IRequest<Result<GetByIdShippingMethodQueryResponse>>;
