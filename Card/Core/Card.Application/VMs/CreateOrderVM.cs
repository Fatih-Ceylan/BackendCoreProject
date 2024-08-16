using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.VMs
{
    public class CreateOrderVM
    { 
        public OrderStatus Status { get; set; }
        public string Description { get; set; }  
        public string CargoId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
