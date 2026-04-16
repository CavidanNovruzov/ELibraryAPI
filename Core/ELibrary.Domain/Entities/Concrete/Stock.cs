using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Stock : BaseEntity
{  
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid BranchId { get; set; }
    public Branch Branch { get; set; }

    public int Quantity { get; set; }
}