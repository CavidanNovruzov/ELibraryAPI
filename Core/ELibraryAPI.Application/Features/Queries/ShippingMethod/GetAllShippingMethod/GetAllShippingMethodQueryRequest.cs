using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ShippingMethod.GetAllShippingMethod;

public sealed record GetAllShippingMethodQueryRequest : IRequest<Result<GetAllShippingMethodQueryResponse>>;
