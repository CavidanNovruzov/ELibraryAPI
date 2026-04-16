using global::ELibraryAPI.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public sealed class AuthorConfiguration : BaseEntityConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder.ToTable("Authors", "Catalog");

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Biography)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.ImagePath)
            .HasMaxLength(1000);

        builder.Property(x => x.Country)
            .HasMaxLength(100);

        builder.HasIndex(x => x.FullName)
            .IsUnique();

        builder.HasMany(x => x.ProductAuthors)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
