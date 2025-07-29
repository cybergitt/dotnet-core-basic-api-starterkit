using BAS.API;
using BAS.API.Extensions;
using BAS.Application.Common.Setting;
using BAS.Infrastructure.Extensions;
using BAS.Infrastructure.Logging;
using Serilog;


StaticLogger.EnsureInitialized();
Log.Information("Server Booting Up...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.json",
        optional: true,
        reloadOnChange: true);

    //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var environment = builder.Environment.EnvironmentName;
    builder.Configuration.AddJsonFile($"appsettings.{environment}.json",
        optional: true,
        reloadOnChange: true);
    builder.Configuration.AddEnvironmentVariables();

    builder.WebHost.UseKestrel(opt =>
    {
        opt.AddServerHeader = false;
    });

    builder.Host.UseSerilog((context, logConfig) =>
    {
        logConfig
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name)
            .Enrich.WithProperty("Environment", context.HostingEnvironment)
            .Enrich.With(new ThreadPriorityEnricher());
    });
  builder.Services.RegisterEndpointsFromAssemblyContaining<IApiMarker>();

    // Add services to the container.

    // Bind AppSettings and add it to the services collection
    builder.Services.AddOptions<AppSettings>().Bind(builder.Configuration.GetSection(nameof(AppSettings)));
    builder.Services.AddOptions<DbSettings>().Bind(builder.Configuration.GetSection(nameof(DbSettings)));
    builder.Services.AddOptions<CacheSettings>().Bind(builder.Configuration.GetSection(nameof(CacheSettings)));

    builder.Services.AddInfrastructureLayer(builder.Configuration);
    builder.Services.AddApiLayer(builder.Configuration);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Configure Serilog for logging
    app.UseSerilogRequestLogging(opt => opt.EnrichDiagnosticContext = RequestEnricher.LogAdditionalInfo);

    app.UseHttpsRedirection();

    // To prevent man-in-the-middle (MITM) attacks and automatically convert HTTP requests made by the client to HTTPS
    if (!app.Environment.Equals("Local") && !app.Environment.IsDevelopment())
    {
        app.UseHsts();
    }

    app.MapEndpoints();

    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "The HostBuilder terminated unexpectedly");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush(); // ensure all logs written before app exits
}
