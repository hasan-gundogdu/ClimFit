using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class TestDepartmentEntityService : BaseEntityService<TestDepartmentDto,TestDepartment>, ITestDepartmentEntityService
    {
        private readonly IRepository<TestDepartment, Guid> _testDepartmentRepository;
        public TestDepartmentEntityService(IRepository<TestDepartment, Guid> testDepartmentRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(testDepartmentRepository, unitOfWork, mapper)
        {
            _testDepartmentRepository = testDepartmentRepository ?? throw new ArgumentNullException(nameof(testDepartmentRepository));
        }
    }
}