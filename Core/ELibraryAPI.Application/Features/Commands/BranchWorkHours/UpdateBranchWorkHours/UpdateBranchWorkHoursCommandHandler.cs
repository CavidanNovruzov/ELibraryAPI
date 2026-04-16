using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BranchWorkHours.UpdateBranchWorkHours;

public sealed class UpdateBranchWorkHoursCommandHandler : IRequestHandler<UpdateBranchWorkHoursCommandRequest, Result<UpdateBranchWorkHoursCommandResponse>>
{
    public Task<Result<UpdateBranchWorkHoursCommandResponse>> Handle(UpdateBranchWorkHoursCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
