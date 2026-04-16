using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.AppUserPermission.DeleteAppUserPermission;

public sealed record DeleteAppUserPermissionCommandRequest(Guid Id) : IRequest<Result>;
