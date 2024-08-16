using BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Domain.Entities.HR.Employment
{
    public class JobHistory : B_BaseEntity
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? DepartmentId { get; set; }

        public Employee Employee { get; set; }

        public Department Department { get; set; }
    }
}
