using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Language : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
// Az, En, Ru
