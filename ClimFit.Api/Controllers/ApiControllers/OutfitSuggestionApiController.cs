using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.Services;
using ClimFit.Common.DTOs;
using ClimFit.Common.DTOs.External;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class OutfitSuggestionApiController : BaseApiController<int, OutfitSuggestionDto, IOutfitSuggestionEntityService>
    {
        private readonly IOutfitSuggestionEntityService _outfitSuggestionService;
        private readonly IOutfitItemEntityService _outfitItemService;
        private readonly IClothingItemEntityService _clothingItemService;
        private readonly IOpenAiApiService _openAiApiService;
        

        public OutfitSuggestionApiController(IOutfitSuggestionEntityService outfitSuggestionService,
            IOutfitItemEntityService outfitItemService,
            IClothingItemEntityService clothingItemService,
            IOpenAiApiService openAiApiService) : base(outfitSuggestionService)
        {
            _outfitSuggestionService = outfitSuggestionService;
            _outfitItemService = outfitItemService;
            _clothingItemService = clothingItemService;
            _openAiApiService = openAiApiService;
        }

        

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateOutfitSuggestionAsync([FromBody] OutfitSuggestionRequest request)
        {
            if (request == null || request.ClothingItems == null || !request.ClothingItems.Any())
            {
                return BadRequest("Invalid request data.");
            }

            var aiResponse = await _openAiApiService.GetOutfitSuggestionAsync(request);

            if (aiResponse == null)
            {
                return StatusCode(500, "Failed to generate outfit suggestion.");
            }

            var openAiJsonDoc = JsonDocument.Parse(aiResponse);

            // content'e ulaþ
            var contentString = openAiJsonDoc
                .RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            if (string.IsNullOrEmpty(contentString))
            {
                throw new Exception("Content boþ geldi, OpenAI cevabý hatalý olabilir.");
            }



            var parsedAiResponse = JsonSerializer.Deserialize<OpenAiParsedResponse>(contentString);

            if (parsedAiResponse == null || parsedAiResponse.SelectedClothingItemIds == null)
            {
                return StatusCode(500, "Invalid AI response structure.");
            }


            var outfitSuggestion = new OutfitSuggestionDto
            {
                UserId = request.UserId,
                WeatherLogId = request.WeatherLogId,
                SuggestedText = parsedAiResponse.Description,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                CreatorUserId = request.UserId 
            };

           var id= await _outfitSuggestionService.PersistAddAsync(outfitSuggestion);
            outfitSuggestion.Id = id;
            List<OutfitItemDto> outfitItems = new List<OutfitItemDto>();
            // Þimdi OutfitItems kayýtlarýný yapalým
            foreach (var clothingItemId in parsedAiResponse.SelectedClothingItemIds)
            {
                var outfitItem = new OutfitItemDto
                {
                    OutfitSuggestionId = outfitSuggestion.Id,
                    ClothingItemId = clothingItemId,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.UtcNow,
                    CreatorUserId = request.UserId
                };
                outfitItems.Add(outfitItem);


            }
            await _outfitItemService.PersistAddRangeAsync(outfitItems);

            var list = await (await _clothingItemService.GetWhereAsync(c => parsedAiResponse.SelectedClothingItemIds.Contains(c.Id))).ToListAsync();

            var resultDto = new OutfitSuggestionResponseDto
            {
                OutfitSuggestionId = outfitSuggestion.Id,
                SuggestedText = outfitSuggestion.SuggestedText,
                CreatedDate = outfitSuggestion.CreatedDate,
                ClothingItems = list
            };

            return Ok(resultDto);
        }
    }
} 