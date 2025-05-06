using ClimFit.Abstractions.BusinessEntityServiceInterfaces;
using ClimFit.Abstractions.DataAccessInterfaces;
using ClimFit.Business.EntityServices._Base;
using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.EntityServices
{
    public class TestPersonEntityService : BaseEntityService<TestPersonDto, TestPerson>, ITestPersonEntityService
    {
        private readonly IRepository<TestPerson, Guid> _testPersonRepository;
        public TestPersonEntityService(IRepository<TestPerson, Guid> testPersonRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(testPersonRepository, unitOfWork, mapper)
        {
            _testPersonRepository = testPersonRepository ?? throw new ArgumentNullException(nameof(testPersonRepository));
        }
    }
}