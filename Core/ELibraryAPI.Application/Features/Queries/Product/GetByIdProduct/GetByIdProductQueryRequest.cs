using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Product.GetByIdProduct;

public sealed record GetByIdProductQueryRequest(Guid Id) : IRequest<Result<GetByIdProductQueryResponse>>;
