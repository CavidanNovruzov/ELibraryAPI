using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Banner.GetByIdBanner;

public sealed record GetByIdBannerQueryRequest(Guid Id) : IRequest<Result<GetByIdBannerQueryResponse>>;
