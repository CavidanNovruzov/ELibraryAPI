

using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class ProductTag:BaseEntity
{
    public Product Product { get; set; }
    public Tag Tag { get; set; }

    public Guid ProductId { get; set; }
    public Guid TagId { get; set; }
}
