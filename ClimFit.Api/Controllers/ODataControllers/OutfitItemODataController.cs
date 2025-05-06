using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class OutfitItemODataController : BaseODataController<OutfitItemDto, IOutfitItemEntityService>
    {
        private readonly IOutfitItemEntityService _outfitItemEntityService;

        public OutfitItemODataController(IOutfitItemEntityService outfitItemEntityService) : base(outfitItemEntityService)
        {
            _outfitItemEntityService = outfitItemEntityService;
        }

        [HttpGet]
        [EnableQuery]
        public async override Task<IActionResult> Get()
        {
            var res = await _outfitItemEntityService.GetWhereAsync(x => x.OutfitSuggestionId != Guid.Empty);
            return Ok(res);
        }
    }
} 