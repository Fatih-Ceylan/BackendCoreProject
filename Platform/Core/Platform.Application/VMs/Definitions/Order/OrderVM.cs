using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.VMs.Definitions.Order
{
    public class OrderVM: BaseVM
    {
        public string OrderIdFromModule { get; set; }
        
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

        public string? Status { get; set; }

        public string? Description { get; set; }

        public string CargoCompanyName { get; set; }

        public string CargoTrackingNo { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyUrlPath { get; set; }

    }
}