using BAS.Application.Common.Setting;
using BAS.Application.Middlewares;
using BAS.Application.Security.Authentication;
using BAS.Infrastructure.Persistence;
using BAS.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BAS.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRedisConfig(configuration);
            services.AddRepositories();
            services.AddTransient<SecurityHeaderMiddleware>();
            services.AddTransient<AntiXssMiddleware>();
            services.AddTransient<ICachedApiKeyValidation, CachedApiKeyValidation>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var dbSection = configuration.GetSection(nameof(DbSettings));
            services.Configure<DbSettings>(dbSection);
            var dbSettings = dbSection.Get<DbSettings>();

            var connUrl = string.Empty;
            //var serviceProvider = services.BuildServiceProvider();
            //var encryptionService = serviceProvider.GetService<IEncryptionService>();
            //bool envShouldEncrypt = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";
            //if (!envShouldEncrypt)
            //{
            //    connUrl = dbSettings.DbConnectionUrl;
            //}
            //else
            //{
            //    connUrl = encryptionService.Decrypt(dbSettings.DbConnectionUrl);
            //}
            connUrl = dbSettings.DbConnectionUrl;

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer(connectionString,
                //    sqlServerOptionsAction: sqlOptions =>
                //    {
                //        sqlOptions.EnableRetryOnFailure(
                //        maxRetryCount: 3,
                //        maxRetryDelay: TimeSpan.FromSeconds(30),
                //        errorNumbersToAdd: null);
                //        sqlOptions.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName);
                //    }
                //);
                options.UseSqlServer(connUrl,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: dbSettings.MaxRetryCount,
                            maxRetryDelay: TimeSpan.FromSeconds(dbSettings.MaxRetryDelay),
                            errorNumbersToAdd: null
                        );
                        sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    }
                );
            });
        }

        public static void AddRedisConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var cacheSection = configuration.GetSection(nameof(CacheSettings));
            services.Configure<CacheSettings>(cacheSection);
            var cacheSettings = cacheSection.Get<CacheSettings>();

            //var serviceProvider = services.BuildServiceProvider();
            //var encryptionService = serviceProvider.GetService<IEncryptionService>();

            services.AddStackExchangeRedisCache(options =>
            {
                //options.Configuration = configuration.GetConnectionString("RedisConn");
                //bool envShouldEncrypt = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";
                //if (!envShouldEncrypt)
                //{
                //    options.Configuration = cacheOptions.CacheConnectionUrl;
                //}
                //else
                //{
                //    options.Configuration = encryptionService.Decrypt(cacheOptions.CacheConnectionUrl);
                //}
                //options.InstanceName = "MPCache_";
                options.Configuration = cacheSettings.CacheConnectionUrl;
                //options.InstanceName = "BASCache_";
                options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
                {
                    AbortOnConnectFail = true,
                    EndPoints = { options.Configuration }
                };
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
        }
    }
}
