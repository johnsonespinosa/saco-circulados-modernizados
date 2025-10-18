using Microsoft.AspNetCore.Authorization;
using SACO.Application.Abstractions.Auth;

namespace SACO.Infrastructure.Auth;

public sealed class PermissionAuthorizationHandler(IPermissionProvider permissionProvider, IUserContext userContext)
    : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var user = userContext.GetCurrentUser();
        if (user is null)
            return;

        var permissions = await permissionProvider.GetForUserIdAsync(user.Id);
        if (permissions.Contains(requirement.Permission))
            context.Succeed(requirement);
    }
}