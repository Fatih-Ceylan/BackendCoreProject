using System.ComponentModel.DataAnnotations;
using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class LicenseType : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public int UsageMounth { get; set; }

        public int UserNumber { get; set; }

        public int CompanyNumber { get; set; }

        public ICollection<License> Licenses { get; set; }

        public ICollection<GModuleLicenseTypePrice> GModuleLicenseTypePrices { get; set; }
    } 
}