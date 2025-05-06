using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class ClothingItemODataController : BaseODataController<ClothingItemDto, IClothingItemEntityService>
    {
        private readonly IClothingItemEntityService _clothingItemEntityService;

        public ClothingItemODataController(IClothingItemEntityService clothingItemEntityService) : base(clothingItemEntityService)
        {
            _clothingItemEntityService = clothingItemEntityService;
        }

        [HttpGet]
        [EnableQuery]
        public async override Task<IActionResult> Get()
        {
            var res = await _clothingItemEntityService.GetWhereAsync(x => x.Name.Contains("test"));
            return Ok(res);
        }
    }
} 