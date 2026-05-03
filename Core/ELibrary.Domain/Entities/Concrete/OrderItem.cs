using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class OrderItem : BaseEntity, IOwnership
{
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    // Satış anındakı qiymət
    public decimal UnitPrice { get; set; }
    public Guid UserId { get ; set ; }
}