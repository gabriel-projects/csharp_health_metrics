using Api.GRRInnovations.HealthMetrics.Infrastructure.Helpers;
using Api.GRRInnovations.HealthMetrics.Infrastructure.Persistence;
using Api.GRRInnovations.HealthMetrics.Infrastructure.Services;
using Api.GRRInnovations.HealthMetrics.Interfaces.Services;
using CorrelationId.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.GRRInnovations.HealthMetrics.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            services.AddSingleton<IMetricsService, MetricsService>();

            return services;
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connection = ConnectionHelper.GetConnectionString(configuration);

            services.AddDbContextPool<ApplicationDbContext>(options => ConfigureDatabase(options, connection));
        }

        private static void ConfigureDatabase(DbContextOptionsBuilder options, string connection)
        {
            options.UseSqlServer(connection, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                );

                sqlOptions.CommandTimeout(60);
            });

#if DEBUG
            options.LogTo(Console.WriteLine, LogLevel.Information)
                   .EnableSensitiveDataLogging(); // CUIDADO: isso mostra dados sensíveis no log
#endif
        }
    }
}
