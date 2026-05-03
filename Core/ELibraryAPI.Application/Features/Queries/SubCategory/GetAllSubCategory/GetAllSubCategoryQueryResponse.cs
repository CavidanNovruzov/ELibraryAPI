namespace ELibraryAPI.Application.Features.Queries.SubCategory.GetAllSubCategory;

public sealed record GetAllSubCategoryQueryResponse(
    List<SubCategoryListDto> SubCategories
);

public sealed record SubCategoryListDto(
    Guid Id,
    string Name,
    Guid CategoryId,
    string CategoryName,
    int ProductCount
);
