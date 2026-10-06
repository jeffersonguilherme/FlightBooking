using FlightBooking.Application.Common.Errors;

namespace FlightBooking.Application.Common.Results;

public sealed class Result<T>
{
    public T? Value { get; }

    public Failure? Failure { get; }

    public bool IsSuccess => Failure is null;

    public bool IsFailure => !IsSuccess;

    private Result(T value)
    {
        Value = value;
    }

    private Result(Failure failure)
    {
        Failure = failure;
    }

    public static Result<T> Success(T value)
        => new(value);

    public static Result<T> Fail(Failure failure)
        => new(failure);

    public Result<TNew> Map<TNew>(Func<T, TNew> transform)
    {
        if (IsFailure)
            return Result<TNew>.Fail(Failure!);

        return Result<TNew>.Success(
            transform(Value!));
    }

    public Result<TNew> Bind<TNew>(
        Func<T, Result<TNew>> next)
    {
        if (IsFailure)
            return Result<TNew>.Fail(Failure!);

        return next(Value!);
    }
}