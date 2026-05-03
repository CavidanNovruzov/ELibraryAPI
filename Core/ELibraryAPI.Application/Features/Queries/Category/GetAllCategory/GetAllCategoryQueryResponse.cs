namespace ELibraryAPI.Application.Features.Queries.Category.GetAllCategory;

public sealed record GetAllCategoryQueryResponse(
    List<CategoryListDto> Categories
);

public sealed record CategoryListDto(
    Guid Id,
    string Name,
    int SubCategoryCount,
    int ProductCount
);
