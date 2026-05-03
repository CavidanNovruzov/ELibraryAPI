
namespace ELibraryAPI.Domain.Entities.Common;

public abstract class BaseEntity<TKey> : IEntity<TKey>, IAuditEntity where TKey : notnull
{
    public TKey Id { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string CreatedBy { get; set; } = "System";
    public string? UpdatedBy { get; set; }
}

public abstract class BaseEntity : BaseEntity<Guid> 
{
}
