using ClimFit.Common.DTOs._Base;

namespace ClimFit.Common.DTOs
{
    public class OutfitItemDto : AuditableDto<int>
    {
        public required int OutfitSuggestionId { get; set; }
        public required int ClothingItemId { get; set; }
    }
} 