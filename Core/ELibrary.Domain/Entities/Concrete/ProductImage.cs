using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class ProductImage : BaseEntity, ISoftDelete
{
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }

    // Soft Delete: Şəkil silinəndə fiziksel yox, bazadan gizlənsin (opsional)
    public bool IsDeleted { get; set; } = false;

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}