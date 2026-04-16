using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class UserAddress : BaseEntity
{
    public Guid UserId { get; set; }
    public AppUser User { get; set; }
    public string AddressLine { get; set; }
}
