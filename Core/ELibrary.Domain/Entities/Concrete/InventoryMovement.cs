using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class InventoryMovement : BaseEntity
{
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    // Haradan (Çıxış filialı)
    public Guid FromBranchId { get; set; }
    public virtual Branch FromBranch { get; set; } = null!;

    // Haraya (Giriş filialı)
    public Guid ToBranchId { get; set; }
    public virtual Branch ToBranch { get; set; } = null!;

    public int Quantity { get; set; }

    // Növ: Məsələn, "Transfer", "Return", "Sale", "Adjustment"
    public string Type { get; set; } = null!;

    // Təklif: Hərəkətin statusunu izləmək üçün (Məs: Pending, Shipped, Completed)
    public string Status { get; set; } = "Completed";
}