using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class CardVM : BaseVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TaxRate { get; set; } 
    }
}
