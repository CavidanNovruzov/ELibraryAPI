using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Language.DeleteLanguage;

public sealed class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommandRequest, Result>
{
    public Task<Result> Handle(DeleteLanguageCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
