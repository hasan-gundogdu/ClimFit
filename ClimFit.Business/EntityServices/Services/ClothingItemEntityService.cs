using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class ClothingItemEntityService : BaseEntityService<ClothingItemDto, ClothingItem, int>, IClothingItemEntityService
    {
        private readonly IRepository<ClothingItem, int> _clothingItemRepository;
        public ClothingItemEntityService(IRepository<ClothingItem, int> clothingItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(clothingItemRepository, unitOfWork, mapper)
        {
            _clothingItemRepository = clothingItemRepository ?? throw new ArgumentNullException(nameof(clothingItemRepository));
        }
    }
}