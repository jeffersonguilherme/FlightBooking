namespace FlightBooking.Application.Common.Errors;

public sealed record Failure(
    string Code,
    string Message,
    int StatusCode)
{
    public static Failure NotFound =>
        new(
            "Resource.NotFound",
            "Resource not found.",
            404);

    public static Failure Validation =>
        new(
            "Validation.Error",
            "Validation error.",
            400);

    public static Failure Unauthorized =>
        new(
            "Authentication.Unauthorized",
            "Unauthorized.",
            401);

    public static Failure Conflict(string message) =>
        new(
            "Resource.Conflict",
            message,
            409);

    public static Failure InternalServerError =>
        new(
            "InternalServerError",
            "An unexpected error occurred.",
            500);
}