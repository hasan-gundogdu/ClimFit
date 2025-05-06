using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class ClothingItemApiController : BaseApiController<ClothingItemDto, IClothingItemEntityService>
    {
        private readonly IClothingItemEntityService _clothingItemService;

        public ClothingItemApiController(IClothingItemEntityService clothingItemService) : base(clothingItemService)
        {
            _clothingItemService = clothingItemService;
        }
    }
} 