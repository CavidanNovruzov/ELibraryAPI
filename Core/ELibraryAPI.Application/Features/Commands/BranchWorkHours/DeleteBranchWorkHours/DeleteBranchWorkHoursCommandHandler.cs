using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BranchWorkHours.DeleteBranchWorkHours;

public sealed class DeleteBranchWorkHoursCommandHandler : IRequestHandler<DeleteBranchWorkHoursCommandRequest, Result>
{
    public Task<Result> Handle(DeleteBranchWorkHoursCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
