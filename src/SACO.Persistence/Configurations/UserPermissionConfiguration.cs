using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SACO.Domain.Entities;

namespace SACO.Persistence.Configurations;

public sealed class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable("user_permissions");

        builder.HasKey(userPermission => new { userPermission.UserId, userPermission.PermissionId })
            .HasName("pk_user_permissions");
        
        builder.Property(userPermission => userPermission.UserId)
            .HasColumnName("user_id");

        builder.HasOne(userPermission => userPermission.User)
            .WithMany(user => user.Permissions)
            .HasForeignKey(userPermission => userPermission.UserId)
            .HasConstraintName("fk_user_permissions_user_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(userPermission => userPermission.PermissionId)
            .HasColumnName("permission_id");

        builder.HasOne(userPermission => userPermission.Permission)
            .WithMany(permission => permission.Permissions)
            .HasForeignKey(userPermission => userPermission.PermissionId)
            .HasConstraintName("fk_user_permissions_permission_id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
