using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class EmployeeLabelVM : BaseVM
    {
        public string Name { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public int EmployeeCount { get; set; }
        public string? CompanyId { get; set; }
        public int Count { get; set; }
    }
}
