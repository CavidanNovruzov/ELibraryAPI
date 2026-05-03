using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Category : BaseEntity, ISoftDelete
{
    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
}