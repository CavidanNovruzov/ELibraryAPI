using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Branch : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public ICollection<BranchWorkHours> WorkHours { get; set; } = new List<BranchWorkHours>();
    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    public ICollection<InventoryMovement> OutgoingInventoryMovements { get; set; } = new List<InventoryMovement>();
    public ICollection<InventoryMovement> IncomingInventoryMovements { get; set; } = new List<InventoryMovement>();
}


