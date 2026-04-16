using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Branch.GetAllBranch;

public sealed record GetAllBranchQueryRequest : IRequest<Result<GetAllBranchQueryResponse>>;
