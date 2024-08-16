using Utilities.Core.UtilityApplication.VMs;

namespace NLLogistics.Application.VMs.Definitions.Voyage
{
    public class VoyageVM: BaseVM
    {
        public string VesselId { get; set; }

        public string VesselName { get; set; }

        public string Name { get; set; }

        public string VesselVoyage { get; set; }
    }
}