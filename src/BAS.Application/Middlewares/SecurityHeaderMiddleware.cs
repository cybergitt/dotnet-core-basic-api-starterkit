using BAS.Application.Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace BAS.Application.Middlewares
{
    public class SecurityHeaderMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            IHeaderDictionary headers = httpContext.Response.Headers;
            StringValues emptyHeaderValue = string.Empty;

            headers.Remove("X-Powered-By");
            headers.Remove("X-AspNet-Version");
            headers.Remove("Server");

            httpContext.Response.OnStarting(() =>
            {
                // X-Frame-Options
                AppHelper.AddHeaderIfNotExists(httpContext, "X-Frame-Options", "DENY");

                // X-XSS-Protection
                AppHelper.AddHeaderIfNotExists(httpContext, "X-XSS-Protection", "0");

                // X-Content-Type-Options
                AppHelper.AddHeaderIfNotExists(httpContext, "X-Content-Type-Options", "nosniff");

                // Referrer-Policy HTTP
                AppHelper.AddHeaderIfNotExists(httpContext, "Referrer-Policy", "strict-origin-when-cross-origin");

                // HTTP Strict-Transport-Security (HSTS) handled by code use it for production only

                // Content Security Policy (CSP)
                AppHelper.AddHeaderIfNotExists(httpContext, "Content-Security-Policy", "default-src 'none'; script-src 'self'; connect-src 'self'; img-src 'self'; style-src 'self'; frame-ancestors 'self'; form-action 'self';");

                // The X-Permitted-Cross-Domain-Policies header is used to permit cross-domain requests from Flash and PDF documents
                // In most cases, these permissions are defined in an XML document called crossdomain.xml found in the root directory of the web page.
                AppHelper.AddHeaderIfNotExists(httpContext, "X-Permitted-Cross-Domain-Policies", "none");

                // Permissions-Policy allows you to control which origins can use which browser features, both in the top-level page and in embedded frames.
                // https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Headers_Cheat_Sheet.html#recommendation_13
                AppHelper.AddHeaderIfNotExists(httpContext, "Permissions-Policy", "interest-cohort=(), autoplay=(), encrypted-media=(), fullscreen=(), geolocation=(), microphone=(), midi=(), camera=(), gyroscope=(), magnetometer=(), usb=()");

                return Task.CompletedTask;
            });

            await next(httpContext);
        }
    }
}
