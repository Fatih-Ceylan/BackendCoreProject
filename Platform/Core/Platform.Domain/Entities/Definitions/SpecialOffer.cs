using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class SpecialOffer : BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Guid GModuleId { get; set; }

        public decimal DiscountRate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public Company Company { get; set; }

        public GModule GModule { get; set; }

    }
}