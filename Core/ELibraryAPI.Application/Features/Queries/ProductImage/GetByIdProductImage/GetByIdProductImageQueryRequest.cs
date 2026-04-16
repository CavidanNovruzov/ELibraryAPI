using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductImage.GetByIdProductImage;

public sealed record GetByIdProductImageQueryRequest(Guid Id) : IRequest<Result<GetByIdProductImageQueryResponse>>;
