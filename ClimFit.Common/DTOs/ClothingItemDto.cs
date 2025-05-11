using ClimFit.Common.DTOs._Base;
using ClimFit.Common.Enums;

namespace ClimFit.Common.DTOs
{
    public class ClothingItemDto : AuditableDto<int>
    {
        public required string Name { get; set; }
        public ClothingCategory Category { get; set; }
        public ClothingMaterial Material { get; set; }
        public string? Color { get; set; }
        public string? ImageUrl { get; set; }
        public string? Notes { get; set; }
        public required Guid UserId { get; set; }
    }
} 