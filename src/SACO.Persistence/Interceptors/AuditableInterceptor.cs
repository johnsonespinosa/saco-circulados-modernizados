using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SACO.Application.Abstractions.Auth;
using SACO.Domain.Common;
using SACO.SharedKernel;

namespace SACO.Persistence.Interceptors;

public sealed class AuditableInterceptor(IUserContext userContext, IDateTimeProvider timeProvider) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context is null) return base.SavingChangesAsync(eventData, result, cancellationToken);
        
        var currentUser = userContext.GetCurrentUser();

        foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = timeProvider.UtcNow;
                    entry.Entity.CreatedBy = currentUser!.UserName;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedAt = timeProvider.UtcNow;
                    entry.Entity.ModifiedBy = currentUser!.UserName;
                    break;
                case EntityState.Deleted:
                    entry.Entity.ModifiedAt = timeProvider.UtcNow;
                    entry.Entity.ModifiedBy = currentUser!.UserName;
                    entry.State = EntityState.Modified; // Soft delete
                    break;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}