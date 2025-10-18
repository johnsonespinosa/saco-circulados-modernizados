namespace SACO.Domain.Entities;

public sealed class Permission
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    private readonly List<UserPermission> _userPermissions = [];
    public ICollection<UserPermission> Permissions => _userPermissions.AsReadOnly();
}
