using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.AppUserPermission.GetAllAppUserPermission;

public sealed record GetAllAppUserPermissionQueryRequest : IRequest<Result<GetAllAppUserPermissionQueryResponse>>;
