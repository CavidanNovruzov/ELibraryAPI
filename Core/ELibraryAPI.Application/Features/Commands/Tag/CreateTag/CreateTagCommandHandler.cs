using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Tag.CreateTag;

public sealed class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, Result<CreateTagCommandResponse>>
{
    public Task<Result<CreateTagCommandResponse>> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
