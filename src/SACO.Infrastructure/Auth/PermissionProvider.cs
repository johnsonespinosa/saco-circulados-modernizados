using Microsoft.EntityFrameworkCore;
using SACO.Application.Abstractions.Auth;
using SACO.Application.Abstractions.Data;

namespace SACO.Infrastructure.Auth;

internal sealed class PermissionProvider(IApplicationDbContext dbContext)
    : IPermissionProvider
{
    public async Task<HashSet<string>> GetForUserIdAsync(Guid userId)
    {
        var userDb = await dbContext.Users
            .Include(navigationPropertyPath: user => user.Permissions)
            .ThenInclude(userPermission => userPermission.Permission)
            .FirstOrDefaultAsync(user => user.Id == userId);

        if (userDb is null)
            return [];

        var permissions = userDb.Permissions
            .Select(userPermission => userPermission.Permission.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return permissions;
    }
}