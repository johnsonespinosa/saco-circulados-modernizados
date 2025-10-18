using SACO.Application.Abstractions.Messaging;

namespace SACO.Application.Features.Users.Commands.DisableUser;

public sealed record DisableUserCommand(Guid Id) : ICommand;
