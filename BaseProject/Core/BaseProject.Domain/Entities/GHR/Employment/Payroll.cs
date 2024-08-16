namespace BaseProject.Domain.Entities.HR.Employment
{
    public class Payroll : B_BaseEntity
    {
        public Guid? EmployeeId { get; set; }

        public DateTime? Date { get; set; }

        public int? DayCount { get; set; }

        public double? SalaryPaid { get; set; }

        public double? SalaryTotal { get; set; }

        public Employee Employee { get; set; }
    }
}
