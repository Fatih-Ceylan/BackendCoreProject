using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Payroll.Update
{
    public class UpdatePayrollRequest : IRequest<UpdatePayrollResponse>
    {
        public string Id { get; set; }

        public string? EmployeeId { get; set; }

        public DateTime? Date { get; set; }

        public int? DayCount { get; set; }

        public float? SalaryPaid { get; set; }

        public float? SalaryTotal { get; set; }
    }
}
