using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductTag.GetByIdProductTag;

public sealed record GetByIdProductTagQueryRequest(Guid Id) : IRequest<Result<GetByIdProductTagQueryResponse>>;
