using Utilities.Core.UtilityApplication.VMs;

namespace NLLogistics.Application.VMs.Definitions.Vessel
{
    public class VesselVM: BaseVM
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string Year { get; set; }

        public string Imo { get; set; }

        public string Link { get; set; }

    }
}
