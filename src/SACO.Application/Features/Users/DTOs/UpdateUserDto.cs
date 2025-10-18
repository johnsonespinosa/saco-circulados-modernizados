namespace SACO.Application.Features.Users.DTOs;

public sealed class UpdateUserDto
{
    public string UserName { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
}