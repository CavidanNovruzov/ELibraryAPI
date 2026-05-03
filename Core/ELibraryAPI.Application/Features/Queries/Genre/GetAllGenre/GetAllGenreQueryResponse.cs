namespace ELibraryAPI.Application.Features.Queries.Genre.GetAllGenre;

public sealed record GetAllGenreQueryResponse(
    List<GenreListDto> Genres
);

public sealed record GenreListDto(
    Guid Id,
    string Name,
    int ProductCount
);
