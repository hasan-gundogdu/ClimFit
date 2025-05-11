using ClimFit.Data.Entities.Base;

namespace ClimFit.Data.Entities
{
    public class OutfitItem : AuditableEntity<int>

    {
        public required int OutfitSuggestionId { get; set; }
        public required int ClothingItemId { get; set; }
    }
}
