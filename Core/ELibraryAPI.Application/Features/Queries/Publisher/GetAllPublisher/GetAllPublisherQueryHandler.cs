using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Publisher.GetAllPublisher;

public sealed class GetAllPublisherQueryHandler : IRequestHandler<GetAllPublisherQueryRequest, Result<GetAllPublisherQueryResponse>>
{
    public Task<Result<GetAllPublisherQueryResponse>> Handle(GetAllPublisherQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
