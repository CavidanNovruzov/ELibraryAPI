using ELibraryAPI.Application.Abstractions.Services.Auth;
using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Auth.AppUser.RegistrUser;

public sealed class RegistrUserCommandHandler : IRequestHandler<RegistrUserCommandRequest, Result<Guid>>
{
    private readonly IAuthService _authservice;

    public RegistrUserCommandHandler(IAuthService authservice)
    {
        _authservice = authservice;
    }

    public async Task<Result<Guid>> Handle(RegistrUserCommandRequest request, CancellationToken cancellationToken)
    {
       var result= await _authservice.RegisterAsync(new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            UserName = request.UserName
        }, cancellationToken);

        if (!result.IsSuccess)
            return Result<Guid>.Failure(result.Error);

        return Result<Guid>.Success(result.Value);    
    }
}
