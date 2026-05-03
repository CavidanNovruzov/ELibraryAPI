namespace ELibraryAPI.Application.Features.Queries.Banner.GetAllBanner;

public sealed record GetAllBannerQueryResponse(
    List<BannerListDto> Banners
);

public sealed record BannerListDto(
    Guid Id,
    string ImageUrl,
    string RedirectUrl,
    string Title
);
