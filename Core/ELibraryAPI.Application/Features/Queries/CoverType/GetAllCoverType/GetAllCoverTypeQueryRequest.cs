using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.CoverType.GetAllCoverType;

public sealed record GetAllCoverTypeQueryRequest : IRequest<Result<GetAllCoverTypeQueryResponse>>;
