using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductAuthor.GetByIdProductAuthor;

public sealed class GetByIdProductAuthorQueryHandler : IRequestHandler<GetByIdProductAuthorQueryRequest, Result<GetByIdProductAuthorQueryResponse>>
{
    public Task<Result<GetByIdProductAuthorQueryResponse>> Handle(GetByIdProductAuthorQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
