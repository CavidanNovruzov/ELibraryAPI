using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Publisher.GetAllPublisher;

public sealed record GetAllPublisherQueryRequest : IRequest<Result<GetAllPublisherQueryResponse>>;
