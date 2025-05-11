using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class OutfitSuggestionEntityService : BaseEntityService<OutfitSuggestionDto, OutfitSuggestion, int>, IOutfitSuggestionEntityService
    {
        private readonly IRepository<OutfitSuggestion, int> _outfitSuggestionRepository;
        public OutfitSuggestionEntityService(IRepository<OutfitSuggestion, int> outfitSuggestionRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(outfitSuggestionRepository, unitOfWork, mapper)
        {
            _outfitSuggestionRepository = outfitSuggestionRepository ?? throw new ArgumentNullException(nameof(outfitSuggestionRepository));
        }
    }
} 