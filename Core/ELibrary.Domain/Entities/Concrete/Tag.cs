using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Tag : BaseEntity, ISoftDelete
{
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
    public virtual ICollection<ProductTag> ProductTags { get; set; } = new HashSet<ProductTag>();
}
