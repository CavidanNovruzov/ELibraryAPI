using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Permission.DeletePermission;

public sealed record DeletePermissionCommandRequest(Guid Id) : IRequest<Result>;
