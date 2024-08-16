using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.Card.Enums;
using Utilities.Core.UtilityApplication.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class Order : BaseEntity
    {  
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public OrderStatus? Status { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public decimal GeneralTotalAmount { get; set; }
        public decimal GeneralTotalTaxAmount { get; set; }
        public string? CargoTrackingNo { get; set; }
        public Guid? BuyerId { get; set; } 
        public Guid? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public Guid? CompanyId { get; set; } 
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } 
        public ICollection<Card> Cards { get; set; } 
    }
}
