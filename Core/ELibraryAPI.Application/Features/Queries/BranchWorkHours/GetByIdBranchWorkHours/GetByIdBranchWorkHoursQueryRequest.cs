using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BranchWorkHours.GetByIdBranchWorkHours;

public sealed record GetByIdBranchWorkHoursQueryRequest(Guid Id) : IRequest<Result<GetByIdBranchWorkHoursQueryResponse>>;
