namespace ELibraryAPI.Application.Features.Queries.PromoCode.GetAllPromoCode;

public sealed record GetAllPromoCodeQueryResponse(
    List<PromoCodeListDto> PromoCodes
);

public sealed record PromoCodeListDto(
    Guid Id,
    string Code,
    decimal DiscountPercent,
    DateTime StartDate,
    DateTime EndDate,
    int UsageLimit
);
