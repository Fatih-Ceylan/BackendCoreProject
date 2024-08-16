using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.VMs.Definitions.SpecialOffer
{
    public class SpecialOfferVM : BaseVM
    {
        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string GModuleId { get; set; }

        public string GModuleName { get; set; }

        public decimal DiscountRate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }
    }
}