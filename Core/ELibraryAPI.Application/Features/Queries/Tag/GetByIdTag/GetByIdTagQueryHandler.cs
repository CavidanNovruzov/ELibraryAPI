using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Tag.GetByIdTag;

public sealed class GetByIdTagQueryHandler : IRequestHandler<GetByIdTagQueryRequest, Result<GetByIdTagQueryResponse>>
{
    public Task<Result<GetByIdTagQueryResponse>> Handle(GetByIdTagQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
