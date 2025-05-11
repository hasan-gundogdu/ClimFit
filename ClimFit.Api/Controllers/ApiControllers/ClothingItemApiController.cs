using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;

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
            var clothes = await _clothingItemService.GetListAsync();
            var list=clothes.ToList().Where(x => x.CreatorUserId == GetLoggedInUserId());

            return Ok(list.ToList());
        }
    }
}