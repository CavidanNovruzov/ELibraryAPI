using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Language.GetByIdLanguage;

public sealed class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQueryRequest, Result<GetByIdLanguageQueryResponse>>
{
    public Task<Result<GetByIdLanguageQueryResponse>> Handle(GetByIdLanguageQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
