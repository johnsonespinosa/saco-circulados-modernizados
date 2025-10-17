using SACO.Domain.Enums;
using SACO.SharedKernel;

namespace SACO.Domain.Entities;

public sealed class User : IAggregateRoot
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRol Rol { get; set; } = UserRol.Operador;
    public UserStatus Status { get; set; } = UserStatus.Activo;
    
    private User() { }
    
    internal User(string userName, string passwordHash, UserRol rol)
    {
        Id = Guid.NewGuid();
        UserName = userName;
        PasswordHash = passwordHash;
        Rol = rol;
        Status = UserStatus.Activo;
    }
    
    public static User Create(string userName, string passwordHash, UserRol rol)
    {
        return new User(userName, passwordHash, rol);
    }
}