using Api.GRRInnovations.HealthMetrics.Infrastructure;
using Api.GRRInnovations.HealthMetrics.Middlewares;
using CorrelationId;
using CorrelationId.DependencyInjection;
using Elastic.Channels;
using Elastic.Clients.Elasticsearch;
using Elastic.Ingest.Elasticsearch;
using Elastic.Serilog.Sinks;
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

            var elasticUri = _configuration["ElasticConfiguration:Uri"] ?? "http://localhost:9200";

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(new RenderedCompactJsonFormatter()) // 👈 Isso mostra tudo, inclusive o CorrelationId
                .WriteTo.File(
                         path: "Logs/log-.txt",
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] (CorrelationId={CorrelationId}) {Message:lj}{NewLine}{Exception}")
                .WriteTo.Elasticsearch([new Uri(elasticUri)], opts =>
                {
                    // Usando Data Stream (recomendado para Elasticsearch 8+)
                    opts.DataStream = new Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName("app-logs", "console-example", "demo");

                    // Cria o índice/data stream somente em caso de falha
                    opts.BootstrapMethod = BootstrapMethod.Failure;

                    // Ajusta o canal assíncrono de envio (para alta performance)
                    opts.ConfigureChannel = channelOpts =>
                    {
                        channelOpts.BufferOptions = new BufferOptions
                        {
                            OutboundBufferMaxSize = 10
                        };
                    };
                })
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
