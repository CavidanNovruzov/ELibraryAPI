using global::ELibraryAPI.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public sealed class ProductGenreConfiguration : IEntityTypeConfiguration<ProductGenre>
{
    public void Configure(EntityTypeBuilder<ProductGenre> builder)
    {

        builder.HasKey(x => new { x.ProductId, x.GenreId });

        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.GenreId).IsRequired();

        builder.HasIndex(x => x.GenreId);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductGenres)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Genre)
            .WithMany(x => x.ProductGenres)
            .HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
