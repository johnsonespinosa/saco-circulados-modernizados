using SACO.SharedKernel;

namespace SACO.Domain.Errors;

public static class UserErrors
{
    public static Error NotFound(Guid userId)
    {
        return Error.NotFound(code: "Users.NotFound", message: $"No se encontró el usuario con el Id: {userId}");
    }

    public static Error Unauthorized()
    {
        return Error.Failure(code: "Users.Unauthorized", message: "No está autorizado para realizar esta acción.");
    }

    public static readonly Error NotFoundByUserName = Error.NotFound(
        code: "Users.NotFoundByUserName",
        message: "No se encontró el usuario con el nombre especificado");

    public static readonly Error UserNameNotUnique = Error.Conflict(
        code: "Users.UserNameNotUnique",
        message: "El nombre de usuario proporcionado no es único");
}