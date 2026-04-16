using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Branch.DeleteBranch;

public sealed class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommandRequest, Result>
{
    public Task<Result> Handle(DeleteBranchCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
