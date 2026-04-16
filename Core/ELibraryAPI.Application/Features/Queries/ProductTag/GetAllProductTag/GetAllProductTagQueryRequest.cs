using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductTag.GetAllProductTag;

public sealed record GetAllProductTagQueryRequest : IRequest<Result<GetAllProductTagQueryResponse>>;
