using Api.GRRInnovations.HealthMetrics.Infrastructure;
using Api.GRRInnovations.HealthMetrics.Middlewares;
using CorrelationId;
using CorrelationId.DependencyInjection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;
using Serilog;
using Serilog.Formatting.Compact;

namespace Api.GRRInnovations.HealthMetrics
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddInfrastructure(_configuration);

            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .ForwardToPrometheus();

            services.AddDefaultCorrelationId(options =>
            {
                options.AddToLoggingScope = true;
                options.IncludeInResponse = true;
                options.RequestHeader = "X-Correlation-ID";
            });

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(new RenderedCompactJsonFormatter()) // 👈 Isso mostra tudo, inclusive o CorrelationId
                .CreateLogger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpMetrics();

            app.UseRouting();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            app.UseCorrelationId();

            // Prometheus metrics endpoint
            app.UseMetricServer("/metrics");
        }
    }
}
