using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Campaign : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal DiscountPercent { get; set; }
    //public ICollection<ProductCampaign> ProductCampaigns { get; set; }
}
