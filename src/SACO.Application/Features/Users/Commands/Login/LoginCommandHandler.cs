using SACO.Application.Abstractions.Messaging;
using SACO.Application.Features.Users.DTOs;
using SACO.Domain.Entities;
using SACO.Domain.Enums;
using SACO.SharedKernel;

namespace SACO.Application.Features.Users.Commands.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResultDto>
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

    public async Task<Result<LoginResultDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var userDb = SimulatedUsers
            .FirstOrDefault(user => user.UserName == request.UserName && user.Status == UserStatus.Activo);

        if (userDb is null || !VerifyHash(request.Password, userDb.PasswordHash))
        {
            return Result.Failure<LoginResultDto>(Error.Problem(
                code: "Login.Credenciales.Invalidas", 
                message: "Correo o contraseña incorrectos"));
        }

        var dto = new LoginResultDto(userDb.Id, userDb.UserName, userDb.Rol.ToString());

        return Result.Success(dto);
    }

    private static string Hash(string password) => $"hashed:{password}";

    private static bool VerifyHash(string password, string hash) => hash == Hash(password);
}