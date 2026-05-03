using ELibraryAPI.Domain.Entities.Common;


namespace ELibraryAPI.Domain.Entities.Concrete;

public class Stock : BaseEntity
{
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public Guid BranchId { get; set; }
    public virtual Branch Branch { get; set; } = null!;

    public int Quantity { get; set; }
}