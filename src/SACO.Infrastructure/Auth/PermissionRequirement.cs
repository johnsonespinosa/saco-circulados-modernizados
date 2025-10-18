using Microsoft.AspNetCore.Authorization;

namespace SACO.Infrastructure.Auth;

public sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}