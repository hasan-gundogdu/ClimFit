using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class OutfitItemApiController : BaseApiController<OutfitItemDto, IOutfitItemService>
    {
        private readonly IOutfitItemService _outfitItemService;

        public OutfitItemApiController(IOutfitItemService outfitItemService) : base(outfitItemService)
        {
            _outfitItemService = outfitItemService;
        }

        [HttpGet]
        public async override Task<IActionResult> Get()
        {
            var res = await _outfitItemService.GetWhereAsync(x => x.OutfitSuggestionId != Guid.Empty);
            return Ok(res);
        }
    }
} 