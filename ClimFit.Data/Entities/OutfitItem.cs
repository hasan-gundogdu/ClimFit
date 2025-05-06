using ClimFit.Data.Entities.Base;

namespace ClimFit.Data.Entities
{
    public class OutfitItem : AuditableEntity
    {
        public required Guid OutfitSuggestionId { get; set; }
        public required Guid ClothingItemId { get; set; }
    }
}
