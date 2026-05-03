namespace ELibraryAPI.Application.Features.Queries.Campaign.GetAllCampaign;

public sealed record GetAllCampaignQueryResponse(
    List<CampaignListDto> Campaigns
);

public sealed record CampaignListDto(
    Guid Id,
    string Title,
    string Description,
    decimal DiscountPercent,
    DateTime StartDate,
    DateTime EndDate,
    bool IsActiveStatus
);
