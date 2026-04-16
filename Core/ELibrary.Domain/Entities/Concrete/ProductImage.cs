using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class ProductImage : BaseEntity
{
    public string ImageUrl { get; set; }
    public bool IsMain { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
