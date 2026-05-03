using ELibraryAPI.Domain.Entities.Concrete;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // 1. Şəxsi Məlumatlar (nvarchar max olmaması üçün)
        builder.Property(u => u.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(u => u.LastName)
               .HasMaxLength(50)
               .IsRequired();

        // 2. Auth & Token Məntiqi
        builder.HasMany(u => u.RefreshTokens)
               .WithOne(t => t.User)
               .HasForeignKey(t => t.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // 3. Ünvanlar
        // Səndə WithOne() boş idi, onu entity-dəki property-yə bağladıq
        builder.HasMany(u => u.Addresses)
               .WithOne(a => a.User)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // 4. Sifarişlər (KRİTİK!)
        // İstifadəçi silinsə belə, sifariş tarixçəsi (Order) silinməməlidir (Restrict)
        builder.HasMany(u => u.Orders)
               .WithOne(o => o.User)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        // 5. Rəylər (Review)
        builder.HasMany(u => u.Reviews)
               .WithOne(r => r.User)
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // 6. Səbət (Basket)
        // Hər userin 1 səbəti olduğunu fərz etsək (1-to-1)
        builder.HasOne(u => u.Basket)
               .WithOne(b => b.User)
               .HasForeignKey<Basket>(b => b.UserId) // 'AppUserId' yerinə 'UserId' yaz
               .OnDelete(DeleteBehavior.Cascade);

        // 7. Axtarış Tarixçəsi
        builder.HasMany(u => u.SearchHistories)
               .WithOne(s => s.User)
               .HasForeignKey(s => s.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}