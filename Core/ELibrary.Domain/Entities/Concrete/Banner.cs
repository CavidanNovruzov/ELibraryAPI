using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Banner : BaseEntity, ISoftDelete
{
    public string Title { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string? RedirectUrl { get; set; }
    public int Order { get; set; }

    public bool IsDeleted { get; set; } = false;

    public bool IsActive { get; set; } = true;
}