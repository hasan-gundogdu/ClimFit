using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class ClothingItemApiController : BaseApiController<ClothingItemDto, IClothingItemService>
    {
        private readonly IClothingItemService _clothingItemService;

        public ClothingItemApiController(IClothingItemService clothingItemService) : base(clothingItemService)
        {
            _clothingItemService = clothingItemService;
        }

        [HttpGet]
        public async override Task<IActionResult> Get()
        {
            var res = await _clothingItemService.GetWhereAsync(x => x.Name.Contains("test"));
            return Ok(res);
        }
    }
} 