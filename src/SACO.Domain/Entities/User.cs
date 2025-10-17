using SACO.Domain.Enums;

namespace SACO.Domain.Entities;

public sealed class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRol Rol { get; set; } = UserRol.Operador;
    public UserStatus Status { get; set; } = UserStatus.Activo;
}