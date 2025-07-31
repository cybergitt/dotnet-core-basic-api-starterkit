using BAS.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public static IResult ToProblem(this IDictionary<string, string[]> errors, HttpContext context)
        {
            if (errors.Count is 0)
            {
                return Results.Problem();
            }

            return CreateProblem(errors, context);
        }

        private static IResult CreateProblem(Error error, HttpContext context)
        {
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
            var instance = isDevelopment ? null : $"{context.Request.Method} {context.Request.Path}";
            var problemDetails = new ProblemDetails
            {
                Title = error.Code,
                Status = GetStatusCode(error.Code),
                Detail = error.Message,
                Instance = instance,
                Extensions =
                {
                    ["traceId"] = traceId,
                    //{"correlationId",  Guid.NewGuid()},
                    ["timestamp"] = DateTime.UtcNow
                }
            };

            return Results.Problem(problemDetails);
        }

        private static IResult CreateProblem(List<Error> errors, HttpContext context)
        {
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
            var instance = isDevelopment ? null : $"{context.Request.Method} {context.Request.Path}";
            var validationProblem = new ValidationProblemDetails(errors.ToDictionary(k => k.Code, v => new[] { v.Message }));
            validationProblem.Title = "bad_request";
            validationProblem.Status = GetStatusCode(errors.First().Code);
            validationProblem.Detail = "One or more validation errors occurred.";
            validationProblem.Instance = instance;
            validationProblem.Extensions.Add("traceId", traceId);
            //validationProblem.Extensions.Add("correlationId", Guid.NewGuid());
            validationProblem.Extensions.Add("timestamp", DateTime.UtcNow);

            return Results.BadRequest(validationProblem);
        }

        private static IResult CreateProblem(IDictionary<string, string[]> errors, HttpContext context)
        {
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
            var instance = isDevelopment ? null : $"{context.Request.Method} {context.Request.Path}";
            var validationProblem = new ValidationProblemDetails(errors);
            validationProblem.Title = "bad_request";
            validationProblem.Status = (int)StatusCodes.Status400BadRequest;
            validationProblem.Detail = "One or more validation errors occurred.";
            validationProblem.Instance = instance;
            validationProblem.Extensions.Add("traceId", traceId);
            //validationProblem.Extensions.Add("correlationId", Guid.NewGuid());
            validationProblem.Extensions.Add("timestamp", DateTime.UtcNow);

            return Results.BadRequest(validationProblem);
        }

        private static int GetStatusCode(string code) => code switch
        {
            "conflict" => StatusCodes.Status409Conflict,
            "bad_request" => StatusCodes.Status400BadRequest,
            "not_found" => StatusCodes.Status404NotFound,
            "unauthorized" => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
