using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Category : BaseEntity
{

    public string Name
    {
        get; set;
    }
    public ICollection<SubCategory> SubCategories { get; set; }

}
