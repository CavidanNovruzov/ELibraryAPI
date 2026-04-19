using ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistance.Configurations.Auth;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.TokenHash)
               .IsRequired()
               .HasMaxLength(512);

        // Refresh zamanı sürətli tapılması üçün Index
        builder.HasIndex(rt => rt.TokenHash);

        builder.Property(rt => rt.CreatedByIp)
               .HasMaxLength(50);

        builder.Property(rt => rt.RevokedByIp)
               .HasMaxLength(50);

        builder.HasOne(rt => rt.User)
                  .WithMany(u => u.RefreshTokens)
                  .HasForeignKey(rt => rt.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

        builder.Property(rt => rt.TokenHash).HasMaxLength(512).IsRequired();
    }
}
