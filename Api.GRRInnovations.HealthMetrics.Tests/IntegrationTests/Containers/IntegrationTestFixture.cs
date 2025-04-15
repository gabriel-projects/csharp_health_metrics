using Testcontainers.Elasticsearch;

namespace Api.GRRInnovations.HealthMetrics.Tests.IntegrationTests.Containers
{
    public class IntegrationTestFixture : IAsyncLifetime
    {
        public ElasticsearchContainer ElasticContainer { get; private set; }

        public async Task InitializeAsync()
        {
            ElasticContainer = new ElasticsearchBuilder()
            .WithImage("docker.elastic.co/elasticsearch/elasticsearch:8.12.1")
            .WithEnvironment("discovery.type", "single-node")
            .WithEnvironment("xpack.security.enabled", "false")
            .WithEnvironment("xpack.security.transport.ssl.enabled", "false")
            .WithEnvironment("xpack.security.http.ssl.enabled", "false")
            .WithEnvironment("ES_JAVA_OPTS", "-Xms512m -Xmx512m")
            .WithPortBinding(9200, true)
            .Build();

            await ElasticContainer.StartAsync();

            var uri = ElasticContainer.GetConnectionString();
            var uriPublic = ElasticContainer.GetMappedPublicPort(9200);
        }

        public async Task DisposeAsync()
        {
            await ElasticContainer.StopAsync();
        }
    }
}
