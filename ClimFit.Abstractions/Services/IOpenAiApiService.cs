using ClimFit.Common.DTOs.External;

namespace ClimFit.Abstractions.Services
{
    public interface IOpenAiApiService
    {
        Task<string?> GetOutfitSuggestionAsync(OutfitSuggestionRequest request);
    }
}
