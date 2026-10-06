using FlightBooking.Application.Common.Errors;
using FlightBooking.Application.Common.Responses;
using FlightBooking.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightBooking.API.Filters;

public sealed class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var failure = context.Exception switch
        {
            BusinessRuleException ex =>
                new Failure(
                    "BusinessRule",
                    ex.Message,
                    StatusCodes.Status400BadRequest),

            _ => Failure.InternalServerError
        };

        context.Result = new ObjectResult(
            new ResponseModel<object>
            {
                Success = false,
                Message = failure.Message,
                Data = null
            })
        {
            StatusCode = failure.StatusCode
        };

        context.ExceptionHandled = true;
    }
}