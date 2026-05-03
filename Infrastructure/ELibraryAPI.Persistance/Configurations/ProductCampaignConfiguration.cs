using global::ELibraryAPI.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public sealed class ProductCampaignConfiguration : BaseEntityConfiguration<ProductCampaign>
{
    public override void Configure(EntityTypeBuilder<ProductCampaign> builder)
    {
        base.Configure(builder);

        // Composite Key: Bir məhsul bir kampaniyaya yalnız bir dəfə daxil ola bilər
        builder.HasKey(x => new { x.ProductId, x.CampaignId });

        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.CampaignId).IsRequired();

        // Əlaqələr
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductCampaigns)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Campaign)
            .WithMany(x => x.ProductCampaigns)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}