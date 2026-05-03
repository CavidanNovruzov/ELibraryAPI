using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;


namespace ELibraryAPI.Domain.Entities.Concrete;

public class UserAddress : BaseEntity, ISoftDelete, IOwnership
{
    public Guid UserId { get; set; }
    public virtual AppUser User { get; set; } = null!;

    public string AddressLine { get; set; } = null!;
    public string? City { get; set; }
    public bool IsDefault { get; set; } // Əsas ünvan kimi işarələmək üçün

    public bool IsDeleted { get; set; } = false;
}