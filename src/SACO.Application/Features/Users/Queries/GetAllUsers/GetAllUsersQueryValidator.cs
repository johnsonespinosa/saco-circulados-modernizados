using FluentValidation;

namespace SACO.Application.Features.Users.Queries.GetAllUsers;

public sealed class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {
        RuleFor(query => query.Filter.Page)
            .GreaterThan(0).WithMessage("La página debe ser mayor que cero.");

        RuleFor(query => query.Filter.PageSize)
            .InclusiveBetween(1, 100).WithMessage("El tamaño de página debe estar entre 1 y 100.");

        RuleFor(query => query.Filter.SortBy)
            .Must(BeAValidSortField).When(query => !string.IsNullOrWhiteSpace(query.Filter.SortBy))
            .WithMessage("Campo de ordenamiento inválido.");
    }

    private static readonly string[] SourceArray = new[] { "username", "rol", "status" };

    private static bool BeAValidSortField(string? field) => SourceArray.Contains(field?.ToLowerInvariant());
}