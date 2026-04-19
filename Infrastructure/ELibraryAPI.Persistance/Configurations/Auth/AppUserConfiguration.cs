using ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {

        // RefreshToken əlaqəsi (Sənin layihəndəki kritik hissə)
        builder.HasMany(u => u.RefreshTokens)
               .WithOne(t => t.User)
               .HasForeignKey(t => t.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // Libraff üçün əlavə sahələr (FullName və s.)
        builder.Property(u => u.FirstName)
                 .HasMaxLength(50)
                 .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(50)
            .IsRequired();

        // İstifadəçi silinəndə ünvanları və ya səbəti nə olsun? 
        // Adətən Restrict və ya Cascade seçilir.
        builder.HasMany(u => u.Addresses)
               .WithOne()
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}