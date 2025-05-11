using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class OutfitItemEntityService : BaseEntityService<OutfitItemDto, OutfitItem, int>, IOutfitItemEntityService
    {
        private readonly IRepository<OutfitItem, int> _outfitItemRepository;
        public OutfitItemEntityService(IRepository<OutfitItem, int> outfitItemRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(outfitItemRepository, unitOfWork, mapper)
        {
            _outfitItemRepository = outfitItemRepository ?? throw new ArgumentNullException(nameof(outfitItemRepository));
        }
    }
} 