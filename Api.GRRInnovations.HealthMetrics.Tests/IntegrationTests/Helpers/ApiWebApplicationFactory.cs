using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.Elasticsearch;

namespace Api.GRRInnovations.HealthMetrics.Tests.IntegrationTests.Helpers
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        private ElasticsearchContainer _elasticContainer;

        public ApiWebApplicationFactory(ElasticsearchContainer elasticContainer)
        {
            this._elasticContainer = elasticContainer;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureAppConfiguration((context, config) =>
            {
                var port = _elasticContainer.GetMappedPublicPort(9200);

                var settings = new Dictionary<string, string>
                {
                    { "ElasticConfiguration:Uri", $"http://localhost:{port}" }
                };

                config.AddInMemoryCollection(settings);
            });
        }
    }
}
