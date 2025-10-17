namespace SACO.SharedKernel;

public sealed record ValidationError(Error[] Errors) : Error("Validation.General",
    "One or more validation errors occurred",
    ErrorType.Validation)
{
    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(Errors: results.Where(result => result.IsFailure).Select(result => result.Error).ToArray());
}
