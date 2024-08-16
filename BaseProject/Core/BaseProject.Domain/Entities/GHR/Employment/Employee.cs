namespace BaseProject.Domain.Entities.HR.Employment
{
    public class Employee : B_BaseEntity
    {
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? Token { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? HireDate { get; set; }

        public float? Salary { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid? BranchId { get; set; }

        public Guid? DepartmentId { get; set; }

        public Guid? AppellationId { get; set; }

        public Appellation Appellation { get; set; }

        public Guid? ManagedDepartmentId { get; set; }

        public Guid? ManagerId { get; set; }

        public ICollection<EmployeeRoles>? EmployeeRoles { get; set; }

        public ICollection<EducationInfo>? EducationInfos { get; set; }

        public ICollection<Leave>? Leaves { get; set; }

        public ICollection<Payroll>? Payrolls { get; set; }

        public ICollection<JobHistory>? JobHistories { get; set; }

        public ICollection<DepartmentManager>? DepartmentManagers { get; set; }

    }
}
