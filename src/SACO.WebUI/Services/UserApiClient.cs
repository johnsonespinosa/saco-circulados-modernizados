using System.Net.Http.Json;
using SACO.Application.Features.Users.Commands.CreateUser;
using SACO.Application.Features.Users.DTOs;
using SACO.SharedKernel;

namespace SACO.WebUI.Services;

public sealed class UserApiClient(HttpClient http)
{
    private const string Endpoint = "api/users";

    public async Task<PagedResult<UserDto>?> GetUsersAsync(UserFilterDto filter)
    {
        var query = $"?Search={filter.Search}&Page={filter.Page}&PageSize={filter.PageSize}&SortBy={filter.SortBy}&Descending={filter.Descending}";
        return await http.GetFromJsonAsync<PagedResult<UserDto>>($"{Endpoint}{query}");
    }

    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        return await http.GetFromJsonAsync<UserDto>($"{Endpoint}/{id}");
    }

    public async Task<Result<Guid>> CreateUserAsync(CreateUserCommand command)
    {
        var response = await http.PostAsJsonAsync(Endpoint, command);
        return await response.Content.ReadFromJsonAsync<Result<Guid>>() ?? Result.Failure<Guid>(Error.Connection);
    }

    public async Task<Result> UpdateUserAsync(UserDto user)
    {
        var dto = new UpdateUserDto { UserName = user.UserName, Rol = user.Rol };
        var response = await http.PutAsJsonAsync($"{Endpoint}/{user.Id}", dto);
        return await response.Content.ReadFromJsonAsync<Result>() ?? Result.Failure(Error.Connection);
    }

    public async Task<Result> DisableUserAsync(Guid id)
    {
        var response = await http.DeleteAsync($"{Endpoint}/{id}");
        return await response.Content.ReadFromJsonAsync<Result>() ?? Result.Failure(Error.Connection);
    }
}