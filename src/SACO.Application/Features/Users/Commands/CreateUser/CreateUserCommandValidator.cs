using FluentValidation;

namespace SACO.Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.UserName)
            .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
            .MinimumLength(4).WithMessage("Debe tener al menos 4 caracteres.");

        RuleFor(command => command.Password)
            .NotEmpty().WithMessage("La contraseña es obligatoria.")
            .MinimumLength(8).WithMessage("Debe tener al menos 8 caracteres.");

        RuleFor(command => command.Rol)
            .NotEmpty().WithMessage("El rol es obligatorio.")
            .Must(BeAValidRol).WithMessage("Rol inválido.");
    }

    private static readonly string[] SourceArray = ["Supervisor", "Inspector", "Operador"];

    private static bool BeAValidRol(string rol) => SourceArray.Contains(rol);
}