using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SACO.Application.Abstractions.Auth;
using SACO.Application.Features.Users.DTOs;

namespace SACO.Infrastructure.Auth;

public class UserContext(ProtectedLocalStorage storage) : IUserContext
{
    private UserDto? _currentUser;

    public UserDto? GetCurrentUser() => _currentUser;

    public async void SetUser(UserDto user)
    {
        _currentUser = user;
        await storage.SetAsync("user", user);
    }

    public async void CloseSession()
    {
        _currentUser = null;
        await storage.DeleteAsync("user");
    }

    public async Task InitializeAsync()
    {
        var result = await storage.GetAsync<UserDto>("user");
        _currentUser = result.Success ? result.Value : null;
    }
}