namespace SACO.Application.Features.Users.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}