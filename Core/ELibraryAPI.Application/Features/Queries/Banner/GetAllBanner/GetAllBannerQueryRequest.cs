using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Banner.GetAllBanner;

public sealed record GetAllBannerQueryRequest : IRequest<Result<GetAllBannerQueryResponse>>;
