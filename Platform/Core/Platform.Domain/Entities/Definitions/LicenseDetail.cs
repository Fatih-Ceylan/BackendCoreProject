using Platform.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class LicenseDetail : BaseEntity
    {
        public Guid LicenseId { get; set; }

        public Guid? SpecialOfferId { get; set; }

        public LicenseStatusEnum LicenseStatus { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public int Number { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }
     
        public decimal TaxRate { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime StartDate { get; set; }

        public License License { get; set; }
    }
}