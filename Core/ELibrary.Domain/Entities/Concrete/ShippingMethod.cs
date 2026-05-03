using ELibraryAPI.Domain.Entities.Common;


namespace ELibraryAPI.Domain.Entities.Concrete;

public class ShippingMethod : BaseEntity, ISoftDelete
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public bool IsDeleted { get; set; } = false;
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}