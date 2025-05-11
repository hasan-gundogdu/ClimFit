using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class OutfitSuggestionODataController : BaseODataController<int, OutfitSuggestionDto, IOutfitSuggestionEntityService>
    {
        private readonly IOutfitSuggestionEntityService _outfitSuggestionEntityService;

        public OutfitSuggestionODataController(IOutfitSuggestionEntityService outfitSuggestionEntityService) : base(outfitSuggestionEntityService)
        {
            _outfitSuggestionEntityService = outfitSuggestionEntityService;
        }
    }
} 