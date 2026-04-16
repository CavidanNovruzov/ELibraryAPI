using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Tag.GetAllTag;

public sealed class GetAllTagQueryHandler : IRequestHandler<GetAllTagQueryRequest, Result<GetAllTagQueryResponse>>
{
    public Task<Result<GetAllTagQueryResponse>> Handle(GetAllTagQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
