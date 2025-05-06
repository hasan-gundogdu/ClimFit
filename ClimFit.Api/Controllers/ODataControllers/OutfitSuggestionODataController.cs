using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class OutfitSuggestionODataController : BaseODataController<OutfitSuggestionDto, IOutfitSuggestionEntityService>
    {
        private readonly IOutfitSuggestionEntityService _outfitSuggestionEntityService;

        public OutfitSuggestionODataController(IOutfitSuggestionEntityService outfitSuggestionEntityService) : base(outfitSuggestionEntityService)
        {
            _outfitSuggestionEntityService = outfitSuggestionEntityService;
        }
    }
} 