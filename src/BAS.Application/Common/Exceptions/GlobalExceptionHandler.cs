using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BAS.Application.Common.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";
            var instance = isDevelopment ? null : $"{httpContext.Request.Method} {httpContext.Request.Path}";

            _logger.LogError(
                exception,
                "Could not process a request on machine {MachineName}. TraceId: {TraceId}",
                Environment.MachineName,
                traceId
            );

            var (statusCode, detail) = MapException(exception);

            await Results.Problem(
                //type: exception.Get,
                title: exception.GetType().Name,
                statusCode: statusCode,
                detail: detail,
                instance: instance,
                extensions: new Dictionary<string, object?>
                {
                    {"traceId",  traceId},
                    //{"correlationId",  Guid.NewGuid()},
                    {"timestamp",  DateTime.UtcNow}
                }
            ).ExecuteAsync(httpContext);

            return true;
        }

        private static (int StatusCode, string Detail) MapException(Exception exception)
        {
            return exception switch
            {
                ArgumentOutOfRangeException => (StatusCodes.Status400BadRequest, exception.Message),
                BadHttpRequestException => (StatusCodes.Status400BadRequest, exception.Message),
                ArgumentNullException => (StatusCodes.Status401Unauthorized, exception.Message),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, exception.Message),
                ApplicationException => (StatusCodes.Status500InternalServerError, exception.Message),
                _ => (StatusCodes.Status500InternalServerError, exception.Message),
            };
        }
    }
}
