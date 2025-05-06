using ClimFit.Data.Entities.Base;

namespace ClimFit.Data.Entities
{
    public class WeatherLog : AuditableEntity
    {
        public required DateTime Date { get; set; }
        public required string Location { get; set; }
        public double Temperature { get; set; }
        public string? Description { get; set; }
        public double WindSpeed { get; set; }
    }
}
