using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;

namespace SACO.Application.Features.Users.Queries.GetUserById;

public record GetUserByIdQuery(Guid Id) : IQuery<UserDto>;