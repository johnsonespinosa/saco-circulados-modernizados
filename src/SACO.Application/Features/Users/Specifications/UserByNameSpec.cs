using Ardalis.Specification;
using SACO.Domain.Entities;
using SACO.Domain.Enums;

namespace SACO.Application.Features.Users.Specifications;

public sealed class UserByNameSpec : Specification<User>
{
    public UserByNameSpec(string userName)
    {
        Query.Where(user => user.UserName == userName && user.Status == UserStatus.Activo);
    }
}