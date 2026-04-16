using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Language.GetAllLanguage;

public sealed class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQueryRequest, Result<GetAllLanguageQueryResponse>>
{
    public Task<Result<GetAllLanguageQueryResponse>> Handle(GetAllLanguageQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
