using global::ELibraryAPI.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public sealed class AuthorConfiguration : BaseEntityConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        // BaseEntityConfiguration daxilində Id, CreatedDate və s. konfiqurasiya olunur
        base.Configure(builder);

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(150);

        // Best Practice: Geniş mətnlər üçün nvarchar(max) istifadə edirik
        builder.Property(x => x.Biography)
            .HasColumnType("nvarchar(max)")
            .IsRequired(); // Bioqrafiya mütləq olmalıdırsa

        builder.Property(x => x.ImagePath)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(100);

        // Performance: Axtarışları sürətləndirmək üçün index
        builder.HasIndex(x => x.FullName);

        // Əlavə olaraq: Ölkəyə görə filter üçün index
        builder.HasIndex(x => x.Country);

        // Relation: ProductAuthors (Müəllifin kitabları ilə əlaqə)
        builder.HasMany(x => x.ProductAuthors)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
        // Restrict daha təhlükəsizdir: Müəllifin kitabı varsa, müəllifi silməyə icazə vermir
    }
}