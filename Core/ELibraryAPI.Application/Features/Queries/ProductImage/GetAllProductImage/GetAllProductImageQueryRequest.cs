using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductImage.GetAllProductImage;

public sealed record GetAllProductImageQueryRequest : IRequest<Result<GetAllProductImageQueryResponse>>;
