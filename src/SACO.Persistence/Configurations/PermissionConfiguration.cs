using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SACO.Domain.Entities;

namespace SACO.Persistence.Configurations;

public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(permission => permission.Id)
            .HasName("pk_permissions");

        builder.Property(permission => permission.Id)
            .HasColumnName("id");

        builder.Property(permission => permission.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(permission => permission.Name)
            .HasDatabaseName("ix_permissions_name")
            .IsUnique();
    }
}
