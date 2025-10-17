namespace SACO.Application.Features.Users.DTOs;

public sealed class UserFilterDto
{
    public string? Search { get; init; }
    public string? Rol { get; init; }
    public string? Status { get; init; }

    public string? SortBy { get; init; }
    public bool Descending { get; init; }

    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}
