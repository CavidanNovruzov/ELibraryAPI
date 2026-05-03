namespace ELibraryAPI.Application.Features.Queries.Publisher.GetAllPublisher;

public sealed record GetAllPublisherQueryResponse(
    List<PublisherListDto> Publishers
);

public sealed record PublisherListDto(
    Guid Id,
    string Name,
    int BookCount
); 
