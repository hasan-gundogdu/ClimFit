using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class WeatherLogODataController : BaseODataController<WeatherLogDto, IWeatherLogEntityService>
    {
        private readonly IWeatherLogEntityService _weatherLogEntityService;

        public WeatherLogODataController(IWeatherLogEntityService weatherLogEntityService) : base(weatherLogEntityService)
        {
            _weatherLogEntityService = weatherLogEntityService;
        }

        [HttpGet]
        [EnableQuery]
        public async override Task<IActionResult> Get()
        {
            var res = await _weatherLogEntityService.GetWhereAsync(x => x.Date != default);
            return Ok(res);
        }
    }
} 