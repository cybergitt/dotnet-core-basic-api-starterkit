using BAS.Application.Common.Setting;
using BAS.Infrastructure.Persistence;
using BAS.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BAS.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
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

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
        }
    }
}
