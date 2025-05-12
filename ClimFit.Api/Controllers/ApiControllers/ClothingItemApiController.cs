using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class ClothingItemApiController : BaseApiController<int, ClothingItemDto, IClothingItemEntityService>
    {
        private readonly IClothingItemEntityService _clothingItemService;

        public ClothingItemApiController(IClothingItemEntityService clothingItemService) : base(clothingItemService)
        {
            _clothingItemService = clothingItemService;
        }

        [HttpGet]
        public async override Task<IActionResult> Get()
        {
            var userId = GetLoggedInUserId();
            var res =await (await _clothingItemService.GetWhereAsync(x => x.CreatorUserId == userId)).ToListAsync();

            return Ok(res);
        }
        [HttpGet("GetItemsByUserIds")]
        public async  Task<IActionResult> GetýtemsByUserIds(List<int> ids)
        {
            var res = await (await _clothingItemService.GetWhereAsync(x => ids.Equals(x.Id))).ToListAsync();
            return Ok(res);
        }
    }
}