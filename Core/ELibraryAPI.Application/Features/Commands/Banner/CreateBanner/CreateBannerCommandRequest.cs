using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banner.CreateBanner;

public sealed record CreateBannerCommandRequest(
    string ImageUrl,
    string RedirectUrl
) : IRequest<Result<CreateBannerCommandResponse>>;
