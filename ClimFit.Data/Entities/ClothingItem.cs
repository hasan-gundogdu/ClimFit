using ClimFit.Common.Enums;
using ClimFit.Data.Entities.Base;

namespace ClimFit.Data.Entities
{
    public class ClothingItem : AuditableEntity<int>

    {
        public required string Name { get; set; }
        public ClothingCategory Category { get; set; }
        public ClothingMaterial Material { get; set; }
        public string? Color { get; set; }
        public string? ImageUrl { get; set; }
        public string? Notes { get; set; }

        public required Guid UserId { get; set; } // Identity user ID
    }
}
