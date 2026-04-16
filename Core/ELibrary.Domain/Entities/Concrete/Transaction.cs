using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Transaction : BaseEntity
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public string TransactionId { get; set; } 
    public bool IsSuccess { get; set; }
    public string ProviderResponse { get; set; }
    public Order Order { get; set; }
}
