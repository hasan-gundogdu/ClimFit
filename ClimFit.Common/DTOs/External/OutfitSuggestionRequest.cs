namespace ClimFit.Common.DTOs.External
{
    public class OutfitSuggestionRequest
    {
        public Guid UserId { get; set; }
        public Guid WeatherLogId { get; set; }
        public double Temperature { get; set; }
        public string WeatherDescription { get; set; } = string.Empty;
        public List<ClothingItemRequestDto> ClothingItems { get; set; } = new();
    }

    public class ClothingItemRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
