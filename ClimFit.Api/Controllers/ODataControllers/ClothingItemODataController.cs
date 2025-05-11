using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class ClothingItemODataController : BaseODataController<int, ClothingItemDto, IClothingItemEntityService>
    {
        private readonly IClothingItemEntityService _clothingItemEntityService;

        public ClothingItemODataController(IClothingItemEntityService clothingItemEntityService) : base(clothingItemEntityService)
        {
            _clothingItemEntityService = clothingItemEntityService;
        }
    }
} 