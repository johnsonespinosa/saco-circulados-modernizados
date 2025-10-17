using SACO.Application.Abstractions.Messaging;

namespace SACO.Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string UserName,
    string Password,
    string Rol) : ICommand<Guid>;
