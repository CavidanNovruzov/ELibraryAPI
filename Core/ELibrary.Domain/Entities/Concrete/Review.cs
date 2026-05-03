using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Review : BaseEntity, ISoftDelete
{
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public Guid UserId { get; set; }
    public virtual AppUser User { get; set; } = null!;

    public string Comment { get; set; } = null!;

    // 1-5 arası ulduz reytinqi
    public int Rating { get; set; }

    // Admin tərəfindən yoxlanılıbmı?
    public bool IsApproved { get; set; } = false;

    public bool IsDeleted { get; set; } = false;
}