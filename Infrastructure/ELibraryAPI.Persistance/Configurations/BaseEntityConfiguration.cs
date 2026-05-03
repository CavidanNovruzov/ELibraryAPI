using ELibraryAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired()
            .ValueGeneratedOnAdd(); // Yaradılarkən avtomatik generasiya olunur

        builder.Property(x => x.UpdatedDate)
           .HasColumnType("datetime2")
           .IsRequired(false)
           .ValueGeneratedOnUpdate(); // Update zamanı SQL-in bunu görməsi üçün (opsionel)

        builder.Property(x => x.CreatedBy)
            .HasMaxLength(255)
            .HasDefaultValue("System")
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .HasMaxLength(255)
            .IsRequired(false);
    }
}