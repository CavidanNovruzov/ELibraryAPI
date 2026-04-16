using ELibraryAPI.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Features.Commands.Auth.AppUser.LoginUser
{
    public class LoginUserCommandRequest:IRequest<Result<LoginUserCommandResponse>>
    {
        /// <summary>
        /// email və ya username
        /// </summary>
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
