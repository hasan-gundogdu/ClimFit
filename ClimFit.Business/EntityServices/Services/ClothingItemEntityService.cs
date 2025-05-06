using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class ClothingItemEntityService : BaseEntityService<ClothingItemDto, ClothingItem>, IClothingItemEntityService
    {
        private readonly IRepository<ClothingItem, Guid> _clothingItemRepository;
        public ClothingItemEntityService(IRepository<ClothingItem, Guid> clothingItemRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(clothingItemRepository, unitOfWork, mapper)
        {
            _clothingItemRepository = clothingItemRepository ?? throw new ArgumentNullException(nameof(clothingItemRepository));
        }
    }
} 