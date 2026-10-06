namespace FlightBooking.Application.Errors;

public sealed record Failure(int Code, string Message)
{
    public static Failure NotFound => new Failure(404, "Resource not found.");

    public static Failure ValidationError => new(400, "Validation error.");
    public static Failure Unauthorized => new Failure(401, "Unauthorized.");
    public static Failure Conflict => new(409, "Conflict.");
    public static Failure InternalServerError => new(500, "An unexpected error occurred.");
}