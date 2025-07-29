using Microsoft.AspNetCore.Http;
using Serilog;

namespace BAS.Infrastructure.Logging
{
    public static class RequestEnricher
    {
        public static void LogAdditionalInfo(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
            diagnosticContext.Set("RemoteIP", httpContext.Connection.RemoteIpAddress); // If not using proxy and load balancer, we can use this to get client real IP
            diagnosticContext.Set("ClientIP", httpContext.Request.Headers["X-Forwarded-For"].ToString()); // If using proxy and load balancer, we can use this to get client real IP
            diagnosticContext.Set("UserAgent", httpContext.Request.Headers.UserAgent);
        }
    }
}
