using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SACO.Domain.Entities;

namespace SACO.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id)
            .HasName("pk_users");

        builder.Property(user => user.UserName)
            .HasColumnName("username")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.PasswordHash)
            .HasColumnName("password_hash")
            .IsRequired();

        builder.Property(user => user.Rol)
            .HasColumnName("rol")
            .IsRequired();

        builder.Property(user => user.Status)
            .HasColumnName("status")
            .IsRequired();
        
        builder.Property(user => user.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(user => user.CreatedBy)
            .HasColumnName("created_by")
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(user => user.ModifiedAt)
            .HasColumnName("modified_at");
        
        builder.Property(user => user.ModifiedBy)
            .HasColumnName("modified_by")
            .HasMaxLength(100);

        builder.HasIndex(user => user.UserName)
            .HasDatabaseName("ix_users_username")
            .IsUnique();
    }
}