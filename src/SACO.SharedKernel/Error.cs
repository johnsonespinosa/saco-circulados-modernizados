namespace SACO.SharedKernel;

public record Error(string Code, string Message, ErrorType Type)
{
    public static readonly Error None = new(Code: string.Empty, Message: string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new(
        Code: "General.Null",
        Message: "Null value was provided",
        ErrorType.Failure);

    public static Error Failure(string code, string message) =>
        new(code, Message: message, ErrorType.Failure);

    public static Error NotFound(string code, string message) =>
        new(code, Message: message, ErrorType.NotFound);

    public static Error Problem(string code, string message) =>
        new(code, Message: message, ErrorType.Problem);

    public static Error Conflict(string code, string message) =>
        new(code, Message: message, ErrorType.Conflict);
}