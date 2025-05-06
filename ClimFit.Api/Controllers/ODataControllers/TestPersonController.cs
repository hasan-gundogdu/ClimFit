using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class TestPersonController : BaseODataController<TestPersonDto, ITestPersonEntityService>
    {
        private readonly ITestPersonEntityService _testPersonEntityService;

        public TestPersonController(ITestPersonEntityService testPersonEntityService) : base(testPersonEntityService)
        {
            _testPersonEntityService = testPersonEntityService;
        }
    }
}