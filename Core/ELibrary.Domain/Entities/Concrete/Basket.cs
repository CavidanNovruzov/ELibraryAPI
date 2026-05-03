using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Basket : BaseEntity, IOwnership
{
    public Basket()
    {
        BasketItems = new HashSet<BasketItem>();
    }

    public Guid UserId { get; set; }
    public virtual AppUser User { get; set; } = null!;

    public decimal TotalPrice { get; protected set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<BasketItem> BasketItems { get; set; }
}