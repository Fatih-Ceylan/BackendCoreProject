using Utilities.Core.UtilityApplication.VMs;

namespace HR.Application.VMs.Definitions
{
    public class PayrollVM : BaseVM
    {
        public string? EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime? Date { get; set; }

        public int? DayCount { get; set; }

        public double? SalaryPaid { get; set; }

        public double? SalaryTotal { get; set; }
    }
}
