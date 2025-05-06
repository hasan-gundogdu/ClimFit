using ClimFit.Common.DTOs._Base;

namespace ClimFit.Common.DTOs
{
    public class OutfitSuggestionDto : AuditableDto
    {
        public required Guid UserId { get; set; }
        public required Guid WeatherLogId { get; set; }
        public required string SuggestedText { get; set; }
        public bool IsLiked { get; set; }
    }
} 