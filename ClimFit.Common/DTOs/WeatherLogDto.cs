using ClimFit.Common.DTOs._Base;

namespace ClimFit.Common.DTOs
{
    public class WeatherLogDto : AuditableDto<int>

    {
        public required DateTime Date { get; set; }
        public required string Location { get; set; }
        public double Temperature { get; set; }
        public string? Description { get; set; }
        public double WindSpeed { get; set; }
    }
} 