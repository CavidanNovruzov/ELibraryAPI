using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class PaymentMethod : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}