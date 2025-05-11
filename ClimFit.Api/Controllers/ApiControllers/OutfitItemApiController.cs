using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class OutfitItemApiController : BaseApiController<int, OutfitItemDto, IOutfitItemEntityService>
    {
        private readonly IOutfitItemEntityService _outfitItemService;

        public OutfitItemApiController(IOutfitItemEntityService outfitItemService) : base(outfitItemService)
        {
            _outfitItemService = outfitItemService;
        }
    }
} 