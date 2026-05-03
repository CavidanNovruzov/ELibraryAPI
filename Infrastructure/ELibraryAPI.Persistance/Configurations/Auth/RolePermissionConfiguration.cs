
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistance.Configurations.Auth;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");

        // Composite Primary Key: Bir rola eyni icazənin təkrar verilməsini bloklayır
        builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

        builder.HasOne(rp => rp.Role)
               .WithMany()
               .HasForeignKey(rp => rp.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rp => rp.Permission)
               .WithMany(p => p.RolePermissions)
               .HasForeignKey(rp => rp.PermissionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}