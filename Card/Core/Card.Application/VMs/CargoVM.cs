using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class CargoVM : BaseVM
    {
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal CargoPrice { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
    }
}
