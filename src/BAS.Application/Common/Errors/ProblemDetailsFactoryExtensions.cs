using BAS.Application.Common.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BAS.Application.Common.Errors
{
    public static class ProblemDetailsFactoryExtensions
    {
        public static ProblemDetails CreateProblemDetailsFromResult(this ProblemDetailsFactory factory, HttpContext context, Result<object> result)
        {
            var problem = factory.CreateProblemDetails
                (
                    context,
                    statusCode: result.StatusCode ?? 400,
                    title: "Request failed",
                    detail: result.Errors.First().Message
                );

            return problem;
        }
    }
}
