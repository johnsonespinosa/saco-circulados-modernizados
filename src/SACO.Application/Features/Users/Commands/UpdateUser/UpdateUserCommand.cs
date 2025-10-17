using SACO.Application.Abstractions.Messaging;

namespace SACO.Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(
    Guid Id,
    string UserName,
    string Rol) : ICommand;
