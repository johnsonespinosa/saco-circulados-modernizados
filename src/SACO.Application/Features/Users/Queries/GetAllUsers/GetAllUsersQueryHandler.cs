using SACO.Application.Abstractions.Data;
using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;
using SACO.Application.Features.Users.Specifications;
using SACO.Domain.Entities;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Queries.GetAllUsers;

public sealed class GetAllUsersQueryHandler(IReadOnlyRepository<User> repository)
    : IQueryHandler<GetAllUsersQuery, PagedResult<UserDto>>
{
    public async Task<Result<PagedResult<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var spec = new UserFilterSpec(request.Filter);
        var countSpec = new UserFilterSpec(request.Filter);

        var totalCount = await repository.CountAsync(countSpec, cancellationToken);
        var users = await repository.ListAsync(spec, cancellationToken);

        var result = new PagedResult<UserDto>
        {
            Items = users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Rol = user.Rol.ToString(),
                Status = user.Status.ToString()
            }).ToList(),
            TotalCount = totalCount,
            Page = request.Filter.Page,
            PageSize = request.Filter.PageSize
        };

        return Result.Success(result);
    }
}


