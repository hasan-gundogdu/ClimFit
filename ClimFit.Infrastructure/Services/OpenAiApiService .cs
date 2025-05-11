using ClimFit.Abstractions.Services;
using ClimFit.Common.DTOs.External;
using Microsoft.Extensions.Configuration;

namespace ClimFit.Infrastructure.Services
{
    public class OpenAiApiService : IOpenAiApiService
    {
        private readonly IHttpRequestBase _httpRequestBase;
        private readonly IConfiguration _configuration;

        public OpenAiApiService(IHttpRequestBase httpRequestBase, IConfiguration configuration)
        {
            _httpRequestBase = httpRequestBase;
            _configuration = configuration;
        }

        public async Task<string?> GetOutfitSuggestionAsync(OutfitSuggestionRequest request)
        {
            if (request.ClothingItems == null || !request.ClothingItems.Any())
            {
                throw new ArgumentException("Clothing items are required.");
            }

            var apiKey = _configuration["OpenAI:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("OpenAI API Key is not configured.");
            }

            var endpoint = "https://api.openai.com/v1/chat/completions";

            var clothingList = string.Join("\n", request.ClothingItems.Select(x => $"- Id:{x.Id} {x.Name}"));

            var userPrompt = $@"
            Bugün hava {request.Temperature} derece ve {request.WeatherDescription}.
            Elimde şu kıyafetler var:
            {clothingList}
            
            Yalnızca bu kıyafetler arasından seçim yaparak uygun bir kombin öner.Önereceğin kombin tam bir kombin olsun. Üst, iç üst, alt,aksesuar ve ayakkabıdan oluşsun.
            Cevabında seçtiğin kıyafetlerin Id'lerini JSON formatında 'selectedClothingItemIds' alanında listele. 
            Ayrıca açıklamanı 'description' alanında döndür.
";

            var openAiBody = new
            {
                model = "gpt-3.5-turbo",
                //model = "gpt-4o",
                messages = new[]
                {
                    new { role = "system", content = "Sen bir kıyafet kombin asistanısın." },
                    new { role = "user", content = userPrompt }
                },
                temperature = 0.7
            };

            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {apiKey}" }
            };

            var response = await _httpRequestBase.SendAsync<string>(
                HttpMethod.Post,
                endpoint,
                openAiBody,
                contentType: "application/json",
                headers: headers
            );

            if (response == null)
            {
                throw new InvalidOperationException("OpenAI API response is null.");
            }

            return response;
        }
    }
}
