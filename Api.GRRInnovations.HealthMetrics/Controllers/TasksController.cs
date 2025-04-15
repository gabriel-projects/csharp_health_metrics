using Api.GRRInnovations.HealthMetrics.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.GRRInnovations.HealthMetrics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMetricsService _metricsService;

        public TasksController(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [HttpGet("process")]
        public IActionResult ProcessTask()
        {
            // Processamento da tarefa...
            _metricsService.IncrementTasksProcessed();

            return Ok("Tarefa processada com sucesso");
        }
    }
}
