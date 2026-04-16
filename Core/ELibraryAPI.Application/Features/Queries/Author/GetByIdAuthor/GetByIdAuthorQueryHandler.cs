using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Author.GetByIdAuthor;

public sealed class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQueryRequest, Result<GetByIdAuthorQueryResponse>>
{
    public Task<Result<GetByIdAuthorQueryResponse>> Handle(GetByIdAuthorQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
