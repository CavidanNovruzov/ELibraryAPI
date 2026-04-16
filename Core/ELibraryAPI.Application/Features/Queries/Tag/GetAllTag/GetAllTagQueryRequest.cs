using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Tag.GetAllTag;

public sealed record GetAllTagQueryRequest : IRequest<Result<GetAllTagQueryResponse>>;
