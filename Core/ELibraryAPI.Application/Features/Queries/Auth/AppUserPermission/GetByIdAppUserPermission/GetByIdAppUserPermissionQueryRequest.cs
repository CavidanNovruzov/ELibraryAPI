using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.AppUserPermission.GetByIdAppUserPermission;

public sealed record GetByIdAppUserPermissionQueryRequest(Guid Id) : IRequest<Result<GetByIdAppUserPermissionQueryResponse>>;
