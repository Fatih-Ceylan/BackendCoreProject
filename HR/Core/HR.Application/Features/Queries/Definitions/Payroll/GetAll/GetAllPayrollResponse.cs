using HR.Application.VMs.Definitions;

namespace HR.Application.Features.Queries.Definitions.Payroll.GetAll
{
    public class GetAllPayrollResponse
    {
        public int TotalCount { get; set; }

        public List<PayrollVM> PayrollVMs { get; set; }
    }
}
