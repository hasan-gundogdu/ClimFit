using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class OutfitItemEntityService : BaseEntityService<OutfitItemDto, OutfitItem>, IOutfitItemEntityService
    {
        private readonly IRepository<OutfitItem, Guid> _outfitItemRepository;
        public OutfitItemEntityService(IRepository<OutfitItem, Guid> outfitItemRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(outfitItemRepository, unitOfWork, mapper)
        {
            _outfitItemRepository = outfitItemRepository ?? throw new ArgumentNullException(nameof(outfitItemRepository));
        }
    }
} 