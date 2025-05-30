using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Common.DTOs;

namespace ClimFit.Api.Controllers.ODataControllers
{
    public class TestDepartmentController : BaseODataController<TestDepartmentDto, ITestDepartmentEntityService>
    {
        private readonly ITestDepartmentEntityService _testDepartmentEntityService;

        public TestDepartmentController(ITestDepartmentEntityService testDepartmentEntityService) : base(testDepartmentEntityService)
        {
            _testDepartmentEntityService = testDepartmentEntityService;
        }

      
    }
}