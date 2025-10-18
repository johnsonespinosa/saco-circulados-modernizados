namespace SACO.Application.Abstractions.Auth;

public interface IPermissionProvider
{
    Task<HashSet<string>> GetForUserIdAsync(Guid userId);
}