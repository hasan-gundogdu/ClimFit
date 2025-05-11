<<<<<<< HEAD
namespace ClimFit.Common.DTOs.External
=======
﻿namespace ClimFit.Common.DTOs.External
>>>>>>> c8fea66cd05dcb85502e1ba457521e6e35dc1a71
{
    public class OutfitSuggestionRequest
    {
        public Guid UserId { get; set; }
        public int WeatherLogId { get; set; }
        public double Temperature { get; set; }
        public string WeatherDescription { get; set; } = string.Empty;
        public List<ClothingItemRequestDto> ClothingItems { get; set; } = new();
    }

    public class ClothingItemRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
} 
