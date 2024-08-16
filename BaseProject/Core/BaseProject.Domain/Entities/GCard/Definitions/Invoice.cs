using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class Invoice : BaseEntity
    { 
        public string InvoiceNumber { get; set; } 
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid CardId { get; set; }
        public Card Card { get; set; }
        public Guid? CompanyId { get; set; } 
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
