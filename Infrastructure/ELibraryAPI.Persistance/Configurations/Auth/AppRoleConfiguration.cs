using ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasMany(r => r.RolePermissions)
               .WithOne(rp => rp.Role)
               .HasForeignKey(rp => rp.RoleId)
               .IsRequired();
    }
}