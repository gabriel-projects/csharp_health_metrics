using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GRRInnovations.HealthMetrics.Interfaces.Services
{
    public interface IMetricsService
    {
        void IncrementTasksProcessed();
    }
}
