namespace ELibraryAPI.Application.Features.Queries.CoverType.GetAllCoverType;

public sealed record GetAllCoverTypeQueryResponse(
    List<CoverTypeListDto> CoverTypes
);

public sealed record CoverTypeListDto(
    Guid Id,
    string Name,
    int ProductCount
);
