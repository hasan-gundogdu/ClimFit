using System.Text.Json.Serialization;

namespace ClimFit.Common.DTOs.External
{
    public class OpenAiParsedResponse
    {
        [JsonPropertyName("selectedClothingItemIds")]
        public List<int> SelectedClothingItemIds { get; set; } = new();

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }

}
