using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.RolePermission.GetAllRolePermission;

public sealed record GetAllRolePermissionQueryRequest : IRequest<Result<GetAllRolePermissionQueryResponse>>;
