namespace ELibraryAPI.Application.Features.Queries.Tag.GetAllTag;


public sealed record GetAllTagQueryResponse(List<TagListDto> Tags);
public sealed record TagListDto(Guid Id, string Name);