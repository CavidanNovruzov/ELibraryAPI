using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Language : BaseEntity, ISoftDelete
{
    public string Name { get; set; } = null!; // Azerbaycan, English
    public string Code { get; set; } = null!; // az, en, ru

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}