using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banner.UpdateBanner;

public sealed record UpdateBannerCommandRequest(
    Guid Id,
    string ImageUrl,
    string RedirectUrl
) : IRequest<Result<UpdateBannerCommandResponse>>;
