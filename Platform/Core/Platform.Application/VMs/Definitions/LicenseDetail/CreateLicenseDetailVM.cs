using Platform.Domain.Entities.Enums;

namespace Platform.Application.VMs.Definitions.LicenseDetail
{
    public class CreateLicenseDetailVM
    {
        public string? SpecialOfferId { get; set; }

        public LicenseStatusEnum LicenseStatus { get; set; }

        public string Description { get; set; }

        public int Number { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime StartDate { get; set; }
    }
}