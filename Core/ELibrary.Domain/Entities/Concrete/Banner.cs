using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Banner : BaseEntity
{
    public string ImageUrl { get; set; } = null!;
    public string RedirectUrl { get; set; } = null!;
}
