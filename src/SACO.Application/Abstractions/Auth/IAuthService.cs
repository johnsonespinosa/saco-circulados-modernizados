using SACO.Domain.Enums;

namespace SACO.Application.Abstractions.Auth;

public interface IAuthService
{
    bool HasAccess(UserRol rol, string module);
}