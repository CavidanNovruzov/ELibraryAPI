using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Genre : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<ProductGenre> ProductGenres { get; set; } = new List<ProductGenre>();
}
