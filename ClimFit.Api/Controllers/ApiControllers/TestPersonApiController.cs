using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;

namespace ClimFit.Api.Controllers.ApiControllers
{
    public class TestPersonApiController : BaseApiController<TestPersonDto, ITestPersonEntityService>
    {
        private readonly ITestPersonEntityService _testPersonEntityService;

        public TestPersonApiController(ITestPersonEntityService testPersonEntityService) : base(testPersonEntityService)
        {
            _testPersonEntityService = testPersonEntityService;
        }
    }
}