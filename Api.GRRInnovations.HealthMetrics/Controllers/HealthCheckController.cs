using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using System.Threading.Tasks;

namespace Api.GRRInnovations.HealthMetrics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy");
        }

        [HttpGet(nameof(ProcessTaskAsync))]
        public IActionResult ProcessTaskAsync()
        {
            using (LogContext.PushProperty("CorrelationId", HttpContext.TraceIdentifier)) // ou pegue do contexto
            {
                var taskId = Guid.NewGuid();

                _logger.LogInformation("Iniciando processamento da tarefa {TaskId}", taskId);

                // lógica de processamento...

                _logger.LogInformation("Tarefa {TaskId} processada com sucesso", taskId);
            }

            return Ok("Healthy");
        }
    }
}
