using Utilities.Core.UtilityApplication.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class Order: BaseEntity
    {
        public Guid? OrderIdFromModule { get; set; }

        public string OrderNo { get; set; }

        public string ModuleName { get; set; }

        public string BuyerInvoiceTitle { get; set; }

        public string BuyerDeliverAddress { get; set; }

        public string BuyerInvoiceAddress { get; set; }

        public string BuyerInvoiceDistrict { get; set; }

        public string BuyerInvoiceCity { get; set; }

        public string BuyerInvoiceCountry { get; set; }

        public string BuyerInvoiceTaxNo { get; set; }

        public string BuyerInvoiceTaxOffice { get; set; }

        public decimal GeneralTotalDiscountAmount { get; set; }

        public decimal GeneralTotalTaxAmount { get; set; }

        public decimal GeneralTotalAmount { get; set; }

        public OrderStatus? Status { get; set; }

        public string? Description { get; set; }

        public string CargoCompanyName { get; set; }

        public string CargoTrackingNo { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}