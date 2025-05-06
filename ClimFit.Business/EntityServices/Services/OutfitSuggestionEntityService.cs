using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class OutfitSuggestionEntityService : BaseEntityService<OutfitSuggestionDto, OutfitSuggestion>, IOutfitSuggestionEntityService
    {
        private readonly IRepository<OutfitSuggestion, Guid> _outfitSuggestionRepository;
        public OutfitSuggestionEntityService(IRepository<OutfitSuggestion, Guid> outfitSuggestionRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(outfitSuggestionRepository, unitOfWork, mapper)
        {
            _outfitSuggestionRepository = outfitSuggestionRepository ?? throw new ArgumentNullException(nameof(outfitSuggestionRepository));
        }
    }
} 