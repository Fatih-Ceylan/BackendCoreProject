namespace BaseProject.Domain.Entities.HR.Employment
{
    public class DepartmentManager : B_BaseEntity
    {
        public Guid DepartmentId { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
