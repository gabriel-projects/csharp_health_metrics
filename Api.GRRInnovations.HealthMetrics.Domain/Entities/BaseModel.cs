using Api.GRRInnovations.HealthMetrics.Interfaces.Models;

namespace Api.GRRInnovations.HealthMetrics.Domain.Entities
{
    public class BaseModel : IBaseModel
    {
        public Guid Uid { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
