using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BranchWorkHours.CreateBranchWorkHours;

public sealed class CreateBranchWorkHoursCommandHandler : IRequestHandler<CreateBranchWorkHoursCommandRequest, Result<CreateBranchWorkHoursCommandResponse>>
{
    public Task<Result<CreateBranchWorkHoursCommandResponse>> Handle(CreateBranchWorkHoursCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
