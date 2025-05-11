using ClimFit.Common.DTOs._Base;

namespace ClimFit.Common.DTOs
{
    public class OutfitSuggestionDto : AuditableDto<int>
    {
        public required Guid UserId { get; set; }
        public required int WeatherLogId { get; set; }
        public required string SuggestedText { get; set; }
        public bool IsLiked { get; set; }
    }
} 