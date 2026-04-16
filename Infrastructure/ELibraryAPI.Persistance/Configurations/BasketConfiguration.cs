using global::ELibraryAPI.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public sealed class BasketConfiguration : BaseEntityConfiguration<Basket>
{
    public override void Configure(EntityTypeBuilder<Basket> builder)
    {
        base.Configure(builder);
        builder.ToTable(x=>
        {
            x.HasCheckConstraint("CK_Baskets_TotalPrice_NonNegative", "[TotalPrice] >= 0");
        });

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.TotalPrice)
            .HasPrecision(18, 2)
            .HasDefaultValue(0m);

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.HasMany(x => x.BasketItems)
            .WithOne(x => x.Basket)
            .HasForeignKey(x => x.BasketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithOne(x => x.Basket)
            .HasForeignKey<Basket>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
