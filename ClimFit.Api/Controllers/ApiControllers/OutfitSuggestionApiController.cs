using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class OutfitSuggestionApiController : BaseApiController<OutfitSuggestionDto, IOutfitSuggestionService>
    {
        private readonly IOutfitSuggestionService _outfitSuggestionService;

        public OutfitSuggestionApiController(IOutfitSuggestionService outfitSuggestionService) : base(outfitSuggestionService)
        {
            _outfitSuggestionService = outfitSuggestionService;
        }

        [HttpGet]
        public async override Task<IActionResult> Get()
        {
            var res = await _outfitSuggestionService.GetWhereAsync(x => x.UserId != Guid.Empty);
            return Ok(res);
        }
    }
} 