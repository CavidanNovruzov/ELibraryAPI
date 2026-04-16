using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
               .HasForeignKey(rt => rt.UserId);
    }
}
