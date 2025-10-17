using FluentValidation;

namespace SACO.Application.Features.Users.Commands.Login;

internal sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.UserName)
            .NotEmpty().WithErrorCode("Login.Correo.Requerido")
            .EmailAddress().WithErrorCode("Login.Correo.FormatoInvalido");

        RuleFor(command => command.Password)
            .NotEmpty().WithErrorCode("Login.Contraseña.Requerida");
    }
}