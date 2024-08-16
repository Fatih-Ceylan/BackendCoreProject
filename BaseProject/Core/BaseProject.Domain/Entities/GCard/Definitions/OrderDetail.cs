using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class OrderDetail : BaseEntity
    { 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public int TaxRate { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid CardId { get; set; }
        public Card Card { get; set; }
        public Guid PurchasedForStaffId { get; set; }
        public Staff Staff { get; set; }
        public Guid? CompanyId { get; set; } 
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
        public string Description { get; set; }
    }
}
