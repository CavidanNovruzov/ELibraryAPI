using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Genre : BaseEntity, ISoftDelete
{
    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<ProductGenre> ProductGenres { get; set; } = new HashSet<ProductGenre>();
}