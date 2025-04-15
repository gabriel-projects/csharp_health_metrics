using Api.GRRInnovations.HealthMetrics.Tests.IntegrationTests.Containers;
using Api.GRRInnovations.HealthMetrics.Tests.IntegrationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GRRInnovations.HealthMetrics.Tests.IntegrationTests
{
    public class MetricsTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly IntegrationTestFixture _fixture;

        public MetricsTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ProcessTask_Should_Increment_Metric()
        {
            // Act - chama o endpoint que processa a tarefa
            var factory = new ApiWebApplicationFactory(_fixture.ElasticContainer);
            var client = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:8080")
            });

            // Espera breve para o Prometheus registrar a métrica
            await Task.Delay(1000);

            // Act - chama o endpoint de métricas
            var addtaskcountEndpoint = await client.GetAsync("api/tasks/process");
            addtaskcountEndpoint.EnsureSuccessStatusCode();

            var metricsResponse = await client.GetAsync("/metrics");
            var metricsContent = await metricsResponse.Content.ReadAsStringAsync();

            // Assert - verifica se a métrica está presente e foi incrementada
            Assert.Contains("app_tasks_processed_total", metricsContent);
            Assert.Contains("app_tasks_processed_total 1", metricsContent);
        }
    }
}
