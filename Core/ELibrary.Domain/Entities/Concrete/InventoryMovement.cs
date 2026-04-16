using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class InventoryMovement : BaseEntity     
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Guid FromBranchId { get; set; }
    public Branch FromBranch { get; set; } = null!;

    public Guid ToBranchId { get; set; }
    public Branch ToBranch { get; set; } = null!;

    public int Quantity { get; set; }
    public string Type { get; set; } = null!;
}
