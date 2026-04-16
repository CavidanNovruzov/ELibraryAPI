using ELibraryAPI.Domain.Entities.Concrete.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Abstractions.Repositories.Auth;

public interface IRefreshTokenReadRepository
{
    Task<RefreshToken> GetByTokenWithUserAsync(string token, CancellationToken ct = default);
}