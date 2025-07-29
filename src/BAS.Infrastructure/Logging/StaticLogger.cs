using Serilog;

namespace BAS.Infrastructure.Logging
{
    public static class StaticLogger
    {
        public static void EnsureInitialized()
        {
            // Loading configuration or Serilog failed.
            // This will create a logger that can be captured by Azure logger.
            // To enable Azure logger, in Azure Portal:
            // 1. Go to WebApp
            // 2. App Service logs
            // 3. Enable "Application Logging (Filesystem)", "Application Logging (Filesystem)" and "Detailed error messages"
            // 4. Set Retention Period (Days) to 10 or similar value
            // 5. Save settings
            // 6. Under Overview, restart web app
            // 7. Go to Log Stream and observe the logs
            if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();
        }
    }
}
