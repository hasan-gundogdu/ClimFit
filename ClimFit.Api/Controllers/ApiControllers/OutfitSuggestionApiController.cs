using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class OutfitSuggestionApiController : BaseApiController<OutfitSuggestionDto, IOutfitSuggestionEntityService>
    {
        private readonly IOutfitSuggestionEntityService _outfitSuggestionService;

        public OutfitSuggestionApiController(IOutfitSuggestionEntityService outfitSuggestionService) : base(outfitSuggestionService)
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