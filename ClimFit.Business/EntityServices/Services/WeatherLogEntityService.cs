using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class WeatherLogEntityService : BaseEntityService<WeatherLogDto, WeatherLog>, IWeatherLogEntityService
    {
        private readonly IRepository<WeatherLog, Guid> _weatherLogRepository;
        public WeatherLogEntityService(IRepository<WeatherLog, Guid> weatherLogRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(weatherLogRepository, unitOfWork, mapper)
        {
            _weatherLogRepository = weatherLogRepository ?? throw new ArgumentNullException(nameof(weatherLogRepository));
        }
    }
} 