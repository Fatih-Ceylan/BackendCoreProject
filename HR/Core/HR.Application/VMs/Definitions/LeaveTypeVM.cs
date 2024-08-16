using Utilities.Core.UtilityApplication.VMs;

namespace HR.Application.VMs.Definitions
{
    public class LeaveTypeVM : BaseVM
    {
        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}
