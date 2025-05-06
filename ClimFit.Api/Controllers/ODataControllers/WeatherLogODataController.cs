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
    }
} 