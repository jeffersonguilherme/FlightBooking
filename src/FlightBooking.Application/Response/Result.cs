using FlightBooking.Application.Errors;

namespace FlightBooking.Application.Response;

public sealed class Result<T>
{
    public T? Value { get; private set; }
    public Failure? Failure { get; private set; }
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
    public static Result<T> Success(T value) => new(value);
    public static Result<T> Fail(Failure failure) => new(failure);
    public Result<Tnew> Map<Tnew>(Func<T, Tnew> trasnform)
    {
        if(IsFailure)
            return Result<Tnew>.Fail(Failure!);
        
        return Result<Tnew>.Success(trasnform(Value!));
    }

        public Result<TNew> Bind<TNew>(Func<T, Result<TNew>> next)
    {
        if (IsFailure)
            return Result<TNew>.Fail(Failure!);

        return next(Value!);
    }   
}