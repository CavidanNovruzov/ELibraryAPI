using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Author : BaseEntity, ISoftDelete
{
    public Author()
    {
        ProductAuthors = new HashSet<ProductAuthor>();
    }

    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public string Country { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<ProductAuthor> ProductAuthors { get; set; }
}