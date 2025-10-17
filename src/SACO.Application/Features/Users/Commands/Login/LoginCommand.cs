using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;

namespace SACO.Application.Features.Users.Commands.Login;

public sealed record LoginCommand(
    string UserName,
    string Password) : ICommand<LoginResultDto>;