using SACO.Application.Abstractions.Data;
using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;
using SACO.Application.Features.Users.Specifications;
using SACO.Domain.Entities;
using SACO.Domain.Errors;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Queries.GetUserById;

public sealed class GetUserByIdQueryHandler(IReadOnlyRepository<User> repository)
    : IQueryHandler<GetUserByIdQuery, UserDto>
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var spec = new UserByIdSpec(query.Id);
        var user = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        if (user is null)
            return Result.Failure<UserDto>(error: UserErrors.NotFound(query.Id));

        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Rol = user.Rol.ToString(),
            Status = user.Status.ToString()
        };
    }
}
