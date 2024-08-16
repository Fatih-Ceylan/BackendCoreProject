namespace BaseProject.Domain.Entities.HR.Employment
{
    public class EducationInfo : B_BaseEntity
    {
        public Guid EmployeeId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Employee Employee { get; set; }
    }
}
