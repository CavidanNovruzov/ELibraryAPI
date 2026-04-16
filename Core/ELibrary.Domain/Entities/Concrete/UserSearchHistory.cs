using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class UserSearchHistory : BaseEntity
{
    public Guid UserId { get; set; }
    public string SearchQuery { get; set; }
    public AppUser User { get; set; }
}
