using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class WeatherLogApiController : BaseApiController<WeatherLogDto, IWeatherLogService>
    {
        private readonly IWeatherLogService _weatherLogService;

        public WeatherLogApiController(IWeatherLogService weatherLogService) : base(weatherLogService)
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