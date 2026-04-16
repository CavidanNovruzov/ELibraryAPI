using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.BranchWorkHours.GetAllBranchWorkHours;

public sealed record GetAllBranchWorkHoursQueryRequest : IRequest<Result<GetAllBranchWorkHoursQueryResponse>>;
