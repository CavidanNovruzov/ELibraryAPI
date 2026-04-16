using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.RefreshToken.GetAllRefreshToken;

public sealed record GetAllRefreshTokenQueryRequest : IRequest<Result<GetAllRefreshTokenQueryResponse>>;
