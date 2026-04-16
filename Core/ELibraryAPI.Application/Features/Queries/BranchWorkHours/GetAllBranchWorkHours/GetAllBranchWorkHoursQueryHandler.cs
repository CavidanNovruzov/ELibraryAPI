using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BranchWorkHours.GetAllBranchWorkHours;

public sealed class GetAllBranchWorkHoursQueryHandler : IRequestHandler<GetAllBranchWorkHoursQueryRequest, Result<GetAllBranchWorkHoursQueryResponse>>
{
    public Task<Result<GetAllBranchWorkHoursQueryResponse>> Handle(GetAllBranchWorkHoursQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
