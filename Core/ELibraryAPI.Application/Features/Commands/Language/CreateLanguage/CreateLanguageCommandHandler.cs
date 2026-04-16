using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Language.CreateLanguage;

public sealed class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommandRequest, Result<CreateLanguageCommandResponse>>
{
    public Task<Result<CreateLanguageCommandResponse>> Handle(CreateLanguageCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
