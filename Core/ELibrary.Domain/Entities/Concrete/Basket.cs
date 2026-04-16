using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Basket : BaseEntity
{
    public Guid UserId { get; set; }
    public AppUser User { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
}
