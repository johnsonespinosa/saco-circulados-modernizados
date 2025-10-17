using FluentValidation;

namespace SACO.Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("El ID del usuario es obligatorio.");

        RuleFor(command => command.UserName)
            .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
            .MinimumLength(4).WithMessage("Debe tener al menos 4 caracteres.");

        RuleFor(command => command.Rol)
            .NotEmpty().WithMessage("El rol es obligatorio.")
            .Must(BeAValidRol).WithMessage("Rol inválido.");
    }

    private static readonly string[] SourceArray = ["Supervisor", "Inspector", "Operador"];

    private static bool BeAValidRol(string rol) => SourceArray.Contains(rol);
}