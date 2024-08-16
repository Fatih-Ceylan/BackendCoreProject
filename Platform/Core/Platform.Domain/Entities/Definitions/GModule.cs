using Platform.Domain.Entities.Definitions.Files;
using System.ComponentModel.DataAnnotations;
using Utilities.Core.UtilityDomain.Entities;

namespace Platform.Domain.Entities.Definitions
{
    public class GModule : BaseEntity
    {
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? LogoPath { get; set; }

        public ICollection<License> Licenses { get; set; }

        public ICollection<GModuleFile> GModuleFiles { get; set; }

        public ICollection<SpecialOffer> SpecialOffers { get; set; }

        public ICollection<GModuleLicenseTypePrice> GModuleLicenseTypePrices { get; set; }
    }
}