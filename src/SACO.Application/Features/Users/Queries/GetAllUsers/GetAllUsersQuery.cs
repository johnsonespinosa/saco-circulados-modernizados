using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;

namespace SACO.Application.Features.Users.Queries.GetAllUsers;

public sealed record GetAllUsersQuery : IQuery<List<UserDto>>;
