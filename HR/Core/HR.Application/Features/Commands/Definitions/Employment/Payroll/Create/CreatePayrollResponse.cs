namespace HR.Application.Features.Commands.Definitions.Employment.Payroll.Create
{
    public class CreatePayrollResponse
    {
        public string Id { get; set; }

        public string? EmployeeId { get; set; }

        public DateTime? Date { get; set; }

        public int? DayCount { get; set; }

        public float? SalaryPaid { get; set; }

        public float? SalaryTotal { get; set; }

        public string Message { get; set; }
    }
}
