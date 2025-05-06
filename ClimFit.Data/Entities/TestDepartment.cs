using ClimFit.Data.Entities.Base;

namespace ClimFit.Data.Entities
{
    public class TestDepartment : AuditableEntity
    {
        public required string Name { get; set; }
        public int Order { get; set; }

    }
}
