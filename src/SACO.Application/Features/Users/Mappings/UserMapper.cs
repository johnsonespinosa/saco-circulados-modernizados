using SACO.Application.Features.Users.DTOs;

namespace SACO.Application.Features.Users.Mappings;

public static class UserMapper
{
    public static UserDto ToDto(this Domain.Entities.User user) =>
        new()
        {
            Id = user.Id,
            UserName = user.UserName,
            PasswordHash = user.PasswordHash,
            Rol = user.Rol.ToString(),
            Status = user.Status.ToString()
        };
}