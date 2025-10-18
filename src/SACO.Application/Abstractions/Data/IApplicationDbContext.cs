using Microsoft.EntityFrameworkCore;
using SACO.Domain.Entities;

namespace SACO.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; }
    public DbSet<UserPermission> UserPermissions { get; }
    public DbSet<Permission> Permissions { get; }
}