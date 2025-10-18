using Ardalis.Specification;
using SACO.Application.Features.Users.DTOs;
using SACO.Domain.Entities;

namespace SACO.Application.Features.Users.Specifications;

public sealed class UserFilterSpec : Specification<User>
{
    public UserFilterSpec(UserFilterDto filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.Search))
            Query.Where(user => user.UserName.Contains(filter.Search));

        if (!string.IsNullOrWhiteSpace(filter.Rol))
            Query.Where(user => user.Rol.ToString() == filter.Rol);

        if (!string.IsNullOrWhiteSpace(filter.Status))
            Query.Where(user => user.Status.ToString() == filter.Status);

        switch (filter.SortBy?.ToLowerInvariant())
        {
            case "username":
                Query.OrderBy(user => user.UserName, filter.Descending);
                break;
            case "rol":
                Query.OrderBy(user => user.Rol, filter.Descending);
                break;
            case "status":
                Query.OrderBy(user => user.Status, filter.Descending);
                break;
            default:
                Query.OrderBy(user => user.UserName);
                break;
        }

        Query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
    }
}
