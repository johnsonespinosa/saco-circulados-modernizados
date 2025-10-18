using FluentValidation;

namespace SACO.Application.Features.Users.Queries.GetUserById;

public sealed class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty().WithMessage("El ID del usuario es obligatorio.");
    }
}