namespace SACO.Application.Features.Users.DTOs;

public record LoginResultDto(Guid UserId, string UserName, string Rol);