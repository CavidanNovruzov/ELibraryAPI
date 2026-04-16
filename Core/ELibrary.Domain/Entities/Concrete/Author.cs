using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Author : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public string Country { get; set; } = null!;

    public ICollection<ProductAuthor> ProductAuthors { get; set; } = new List<ProductAuthor>();
}
