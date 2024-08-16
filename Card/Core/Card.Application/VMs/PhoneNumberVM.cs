using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class PhoneNumberVM : BaseVM
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string? StaffId { get; set; }
        public string? StaffName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
