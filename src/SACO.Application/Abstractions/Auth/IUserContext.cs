using SACO.Application.Features.Users.DTOs;

namespace SACO.Application.Abstractions.Auth;

public interface IUserContext
{
    UserDto? GetCurrentUser();
    void SetUser(UserDto user);
    void CloseSession();
    Task InitializeAsync();
}