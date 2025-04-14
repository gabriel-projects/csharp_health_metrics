using Microsoft.Extensions.DependencyInjection;

namespace Api.GRRInnovations.HealthMetrics.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
