using BAS.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BAS.API.Extensions
{
    public static class EndpointResultsExtensions
    {
        public static IResult ToProblem(this Error error, HttpContext context)
        {
            return CreateProblem(error, context);
        }

        public static IResult ToProblem(this List<Error> errors, HttpContext context)
        {
            if (errors.Count is 0)
            {
                return Results.Problem();
            }

            return CreateProblem(errors, context);
        }

        private static IResult CreateProblem(Error error, HttpContext context)
        {
            var statusCode = error.Code switch
            {
                "conflict" => StatusCodes.Status409Conflict,
                "bad_request" => StatusCodes.Status400BadRequest,
                "not_found" => StatusCodes.Status404NotFound,
                "unauthorized" => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var problemDetails = new ProblemDetails
            {
                Title = error.Code,
                Status = statusCode,
                Detail = error.Message,
                Extensions =
                {
                    ["traceId"] = context.TraceIdentifier,
                    ["correlationId"] = Guid.NewGuid()
                }
            };

            return Results.Problem(problemDetails);
        }

        private static IResult CreateProblem(List<Error> errors, HttpContext httpContext)
        {
            var statusCode = errors.First().Code switch
            {
                "conflict" => StatusCodes.Status409Conflict,
                "bad_request" => StatusCodes.Status400BadRequest,
                "not_found" => StatusCodes.Status404NotFound,
                "unauthorized" => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var validationProblem = new ValidationProblemDetails(errors.ToDictionary(k => k.Code, v => new[] { v.Message }));
            validationProblem.Status = statusCode;
            validationProblem.Extensions.Add("traceId", httpContext.TraceIdentifier);
            validationProblem.Extensions.Add("correlationId", Guid.NewGuid());

            return Results.BadRequest(validationProblem);
        }
    }
}
