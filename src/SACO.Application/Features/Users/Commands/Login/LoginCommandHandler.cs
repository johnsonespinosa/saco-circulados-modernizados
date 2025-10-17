using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;
using SACO.Domain.Entities;
using SACO.Domain.Enums;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Commands.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, UserDto>
{
    // Repository simulation
    private static readonly List<User> SimulatedUsers = [
        new User()
        {
            Id = Guid.NewGuid(),
            UserName = "Pablo",
            PasswordHash = Hash("123456"),
            Rol = UserRol.Supervisor,
            Status = UserStatus.Activo
        }
    ];

    public async Task<Result<UserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var userDb = SimulatedUsers
            .FirstOrDefault(user => user.UserName == request.UserName && user.Status == UserStatus.Activo);

        if (userDb is null || !VerifyHash(request.Password, userDb.PasswordHash))
        {
            return Result.Failure<UserDto>(Error.Problem(
                code: "Login.Credenciales.Invalidas", 
                message: "Correo o contraseña incorrectos"));
        }

        return Result.Success(new UserDto
        {
            Id = userDb.Id,
            UserName = userDb.UserName,
            Rol = userDb.Rol.ToString(),
            Status = userDb.Status.ToString()
        });

    }

    private static string Hash(string password) => $"hashed:{password}";

    private static bool VerifyHash(string password, string hash) => hash == Hash(password);
}