using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.ProductAuthor.GetAllProductAuthor;

public sealed class GetAllProductAuthorQueryHandler : IRequestHandler<GetAllProductAuthorQueryRequest, Result<GetAllProductAuthorQueryResponse>>
{
    public Task<Result<GetAllProductAuthorQueryResponse>> Handle(GetAllProductAuthorQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
