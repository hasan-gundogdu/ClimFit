using ClimFit.Common.DTOs._Base;

namespace ClimFit.Common.DTOs
{
    public class TestDepartmentDto : AuditableDto
    {
        public required string Name { get; set; }
        public int Order { get; set; }
    }
}
