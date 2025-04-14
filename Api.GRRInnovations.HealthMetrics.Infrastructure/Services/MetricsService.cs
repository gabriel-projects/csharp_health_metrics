using Api.GRRInnovations.HealthMetrics.Interfaces.Services;
using Prometheus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GRRInnovations.HealthMetrics.Infrastructure.Services
{
    public class MetricsService : IMetricsService
    {
        private static readonly Counter TasksProcessedCounter =
            Metrics.CreateCounter("app_tasks_processed_total", "Total de tarefas processadas");

        public void IncrementTasksProcessed() => TasksProcessedCounter.Inc();
    }
}
