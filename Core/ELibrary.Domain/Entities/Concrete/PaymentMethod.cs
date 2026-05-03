using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class PaymentMethod : BaseEntity, ISoftDelete
{
    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}