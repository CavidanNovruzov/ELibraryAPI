using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Language.UpdateLanguage;

public sealed class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommandRequest, Result<UpdateLanguageCommandResponse>>
{
    public Task<Result<UpdateLanguageCommandResponse>> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
