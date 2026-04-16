using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Review : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid UserId { get; set; }
    public AppUser User { get; set; }
    public string Comment { get; set; }
    public int Raiting { get; set; } // 1-5
}