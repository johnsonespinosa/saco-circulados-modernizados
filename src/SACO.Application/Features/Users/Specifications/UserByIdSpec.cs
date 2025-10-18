using Ardalis.Specification;
using SACO.Domain.Entities;
using SACO.Domain.Enums;

namespace SACO.Application.Features.Users.Specifications;

public sealed class UserByIdSpec : Specification<User>
{
    public UserByIdSpec(Guid userId)
    {
        Query.Where(user => user.Id == userId && user.Status == UserStatus.Activo);
    }
}