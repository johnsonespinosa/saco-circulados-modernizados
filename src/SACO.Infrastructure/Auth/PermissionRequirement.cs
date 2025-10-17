using Microsoft.AspNetCore.Authorization;

namespace SACO.Infrastructure.Auth;

internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}