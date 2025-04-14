using Api.GRRInnovations.HealthMetrics.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Api.GRRInnovations.HealthMetrics.Infrastructure.Helpers
{
    public class ConnectionHelper
    {
        public const string ConnectionStringKey = "SqlConnectionString";

        internal static string? GetConnectionString(IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString(ConnectionStringKey);

            Debug.WriteLine($"{nameof(ApplicationDbContextFactory)} sql connection string: {connection}");

            return connection;
        }
    }
}
