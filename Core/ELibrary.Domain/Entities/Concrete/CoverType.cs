using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class CoverType : BaseEntity
{
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public string Name { get; set; }
} 

