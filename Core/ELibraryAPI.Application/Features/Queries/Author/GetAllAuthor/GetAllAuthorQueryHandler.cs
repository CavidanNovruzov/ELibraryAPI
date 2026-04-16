using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Author.GetAllAuthor;

public sealed class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, Result<GetAllAuthorQueryResponse>>
{
    public Task<Result<GetAllAuthorQueryResponse>> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
