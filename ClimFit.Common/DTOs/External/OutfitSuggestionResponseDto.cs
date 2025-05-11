namespace ClimFit.Common.DTOs.External
{
    public class OutfitSuggestionResponseDto
    {
        public int OutfitSuggestionId { get; set; }
        public string SuggestedText { get; set; } = string.Empty;
        public List<ClothingItemDto> ClothingItems { get; set; } = new();
        public DateTime CreatedDate { get; set; }
    }
}
