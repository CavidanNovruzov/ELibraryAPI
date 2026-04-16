using ELibraryAPI.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Features.Commands.Auth.AppUser.RegistrUser;

public record RegistrUserCommandRequest: IRequest<Result<Guid>>
{
    public string FirstName { get; init; } 
    public string LastName { get; init; } 
    public string UserName { get; init; } 
    public string Email { get; init; } 
    public string Password { get; init; } 
}
