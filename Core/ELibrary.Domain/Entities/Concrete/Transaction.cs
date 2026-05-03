using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Enums;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Transaction : BaseEntity, ISoftDelete, IOwnership
{
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;

    public decimal Amount { get; set; }

    // Bankın verdiyi təkrarolunmaz əməliyyat nömrəsi (RRN və ya Reference ID)
    public string TransactionId { get; set; } = null!;

    public TransactionStatus Status { get; set; } = TransactionStatus.Pending;
    public bool IsSuccess { get; set; }

    // Bankdan gələn tam JSON cavabı (Səhv kodları, status və s.)
    public string? ProviderResponse { get; set; }

    public bool IsDeleted { get; set; } = false;
    public Guid UserId { get ; set ; }
}
