namespace BaseProject.Domain.Entities.HR.Employment
{
    public class EmployeeRoles : B_BaseEntity
    {
        public Guid EmployeeId { get; set; }

        public Guid RoleId { get; set; }

        public ICollection<RoleType> RoleTypes { get; set; }
    }
}
