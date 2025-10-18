namespace SACO.Infrastructure.Auth;

internal static class PermissionRegistry
{
    public static readonly string[] All =
    [
        "Usuarios.Ver",
        "Usuarios.Editar",
        "Usuarios.Desactivar",
        "Usuarios.Crear",
        "Usuarios.Auditar",
        "Permisos.Ver",
        "Permisos.Editar"
    ];
}