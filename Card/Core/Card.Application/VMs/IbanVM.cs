using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class IbanVM : BaseVM
    {
        public string IbanNo { get; set; }
        public string? StaffName { get; set; }
        public string? StaffId { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
