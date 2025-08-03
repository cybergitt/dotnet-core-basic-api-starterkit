using BAS.Application.Common.Constants;
using BAS.Application.Security.Authentication;
using Microsoft.AspNetCore.Http;

namespace BAS.Application.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderName = HeaderConstant.ApiKey;
        private readonly ICachedApiKeyValidation _cachedApiKeyValidation;

        public ApiKeyMiddleware(RequestDelegate next, ICachedApiKeyValidation cachedApiKeyValidation)
        {
            _next = next;
            _cachedApiKeyValidation = cachedApiKeyValidation;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(HeaderName, out var apiKeyHeader))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API Key is missing.");
                return;
            }

            if (!_cachedApiKeyValidation.IsValidApiKey(apiKeyHeader!))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid or inactive API Key.");
                return;
            }

            await _next(context);
        }
    }
}
