using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Branch.CreateBranch;

public sealed class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommandRequest, Result<CreateBranchCommandResponse>>
{
    public Task<Result<CreateBranchCommandResponse>> Handle(CreateBranchCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
