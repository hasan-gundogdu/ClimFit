using ClimFit.Data.Entities.Base;

namespace ClimFit.Data.Entities
{
    public class OutfitSuggestion : AuditableEntity<int>

    {
        public required Guid UserId { get; set; }  // Identity user ID
        public required Guid WeatherLogId { get; set; }

        public required string SuggestedText { get; set; }
        public bool IsLiked { get; set; }
    }
}
