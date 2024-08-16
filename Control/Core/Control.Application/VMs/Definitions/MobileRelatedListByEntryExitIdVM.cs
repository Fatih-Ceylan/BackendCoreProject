using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class MobileRelatedListByEntryExitIdVM : BaseVM
    {
        public string EmployeeId { get; set; }
        public string LocationId { get; set; }
        public string BranchId { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string LocationName { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRegistrationType { get; set; }
    }
}
