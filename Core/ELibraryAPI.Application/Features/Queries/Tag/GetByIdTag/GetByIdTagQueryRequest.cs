using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Tag.GetByIdTag;

public sealed record GetByIdTagQueryRequest(Guid Id) : IRequest<Result<GetByIdTagQueryResponse>>;
