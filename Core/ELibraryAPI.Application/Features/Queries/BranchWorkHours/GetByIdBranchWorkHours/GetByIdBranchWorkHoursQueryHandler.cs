using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BranchWorkHours.GetByIdBranchWorkHours;

public sealed class GetByIdBranchWorkHoursQueryHandler : IRequestHandler<GetByIdBranchWorkHoursQueryRequest, Result<GetByIdBranchWorkHoursQueryResponse>>
{
    public Task<Result<GetByIdBranchWorkHoursQueryResponse>> Handle(GetByIdBranchWorkHoursQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
