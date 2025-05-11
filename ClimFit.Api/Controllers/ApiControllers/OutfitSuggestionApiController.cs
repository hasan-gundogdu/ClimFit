using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.Services;
using ClimFit.Common.DTOs;
using ClimFit.Common.DTOs.External;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class OutfitSuggestionApiController : BaseApiController<OutfitSuggestionDto, IOutfitSuggestionEntityService>
    {
        private readonly IOutfitSuggestionEntityService _outfitSuggestionService;
        private readonly IOpenAiApiService _openAiApiService;

        public OutfitSuggestionApiController(IOutfitSuggestionEntityService outfitSuggestionService, IOpenAiApiService openAiApiService) : base(outfitSuggestionService)
        {
            _outfitSuggestionService = outfitSuggestionService;
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

            return Ok(aiResponse);
        }
    }
} 