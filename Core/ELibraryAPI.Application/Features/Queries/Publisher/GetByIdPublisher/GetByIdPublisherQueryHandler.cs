using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Publisher.GetByIdPublisher;

public sealed class GetByIdPublisherQueryHandler : IRequestHandler<GetByIdPublisherQueryRequest, Result<GetByIdPublisherQueryResponse>>
{
    public Task<Result<GetByIdPublisherQueryResponse>> Handle(GetByIdPublisherQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
