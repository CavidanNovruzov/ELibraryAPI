namespace ELibraryAPI.Application.Features.Queries.Author.GetAllAuthor;

public sealed record GetAllAuthorQueryResponse(List<AuthorListDto> Authors, int TotalCount);

public sealed record AuthorListDto(Guid Id, string FullName, string Country, int BookCount);