using ELibraryAPI.Application.Responses;
using MediatR;


namespace ELibraryAPI.Application.Features.Commands.Auth.Roles.AppRole.UpdateRole;

public sealed record UpdateRoleCommandRequest(
   Guid Id,
   string Name) : IRequest<Result>;
