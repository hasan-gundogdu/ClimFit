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

        [HttpGet]
        public async override Task<IActionResult> Get()
        {
            var res = await _weatherLogService.GetWhereAsync(x => x.Date != default);
            return Ok(res);
        }
    }
} 