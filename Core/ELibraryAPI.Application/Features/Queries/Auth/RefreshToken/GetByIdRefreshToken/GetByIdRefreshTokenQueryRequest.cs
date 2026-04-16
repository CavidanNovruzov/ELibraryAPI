using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.RefreshToken.GetByIdRefreshToken;

public sealed record GetByIdRefreshTokenQueryRequest(Guid Id) : IRequest<Result<GetByIdRefreshTokenQueryResponse>>;
