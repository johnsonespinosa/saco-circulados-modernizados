using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Queries.GetAllUsers;

public sealed record GetAllUsersQuery(UserFilterDto Filter) : IQuery<PagedResult<UserDto>>;


