namespace ELibraryAPI.Application.Features.Queries.Branch.GetAllBranch;

public sealed record GetAllBranchQueryResponse(
    List<BranchListDto> Branches
);

public sealed record BranchListDto(
    Guid Id,
    string Name,
    string Location,
    string Phone,
    int WorkHoursCount
);
