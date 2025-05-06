using ClimFit.Common.DTOs._Base;

namespace ClimFit.Common.DTOs
{
    public class OutfitItemDto : AuditableDto
    {
        public required Guid OutfitSuggestionId { get; set; }
        public required Guid ClothingItemId { get; set; }
    }
} 