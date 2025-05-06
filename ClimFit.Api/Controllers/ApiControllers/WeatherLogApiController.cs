using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class WeatherLogApiController : BaseApiController<WeatherLogDto, IWeatherLogEntityService>
    {
        private readonly IWeatherLogEntityService _weatherLogService;

        public WeatherLogApiController(IWeatherLogEntityService weatherLogService) : base(weatherLogService)
        {
            _weatherLogService = weatherLogService;
        }
    }
} 