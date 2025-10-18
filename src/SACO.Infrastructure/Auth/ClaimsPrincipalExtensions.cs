using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace SACO.Infrastructure.Auth;

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        var userId = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userId, out var parsedUserId)
            ? parsedUserId
            : throw new InvalidOperationException("User id is unavailable");
    }
}