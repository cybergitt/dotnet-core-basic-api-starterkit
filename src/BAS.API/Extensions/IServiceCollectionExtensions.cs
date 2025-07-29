using BAS.API.Features.Tasks.Create;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO.Compression;
using System.Net;
using System.Text.Json.Serialization;

namespace BAS.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApiLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", options =>
                {
                    options.AllowAnyOrigin()
                            .WithMethods("GET", "POST")
                            .AllowAnyHeader();
                });
            });

            services.AddAntiforgery(opt =>
            {
                // To remove the X-Frame-Options header information
                opt.SuppressXFrameOptionsHeader = true;
            });

            services.AddHsts(opt =>
            {
                opt.Preload = true;
                opt.IncludeSubDomains = true;
                opt.MaxAge = TimeSpan.FromDays(60);
                //opt.ExcludedHosts.Add("example.com");
                //opt.ExcludedHosts.Add("www.example.com");
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Expiration = TimeSpan.FromHours(1);
                opt.SlidingExpiration = true;
            });

            services.AddHttpsRedirection(opt =>
            {
                //opt.HttpsPort = 7164;
                opt.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
            });

            services.AddZipCompression();
            services.AddValidators();
            services.AddFeatures(configuration);

            services.AddControllers().AddJsonOptions(opt =>
            {
                // Support nested json
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                // Support string to enum conversions
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        public static void AddZipCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
        }

        public static void AddValidators(this IServiceCollection services)
        {
            // Manual Validation - This is the recommended approach.
            //services.AddScoped<IValidator<UploadRequest>, UploadRequestValidator>();
            //services.AddScoped<IValidator<TicketTypeRequest>, TicketTypeRequestValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateTaskRequestValidator>();

            // Automatic Validation - This is deprecated and no longer supported in the latest release of FluentValidation, version 11.9.1
            //services.AddFluentValidationAutoValidation()
            //    .AddFluentValidationClientsideAdapters()
            //    .AddValidatorsFromAssemblyContaining<MenuRequestValidator>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public static void AddFeatures(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
        }
    }


}
