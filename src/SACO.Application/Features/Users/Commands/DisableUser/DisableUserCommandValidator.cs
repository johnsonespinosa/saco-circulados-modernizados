using FluentValidation;

namespace SACO.Application.Features.Users.Commands.DisableUser;

public class DisableUserCommandValidator : AbstractValidator<DisableUserCommand>
{
    public DisableUserCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("El ID del usuario es obligatorio.");
    }
}