using SACO.Application.Abstractions.Auth;
using SACO.Domain.Enums;

namespace SACO.Infrastructure.Auth;

public class AuthService : IAuthService
{
    public bool HasAccess(UserRol rol, string module)
    {
        return rol switch
        {
            UserRol.Supervisor => true,
            UserRol.Inspector => module != "usuarios",
            UserRol.Operador => module == "circulados",
            _ => false
        };
    }
}