using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Product.GetAllProduct;

public sealed record GetAllProductQueryRequest : IRequest<Result<GetAllProductQueryResponse>>;
