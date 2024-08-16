using Utilities.Core.UtilityApplication.VMs;

namespace NLLogistics.Application.VMs.Definitions.Port
{
    public class PortVM : BaseVM
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public string? CountryName { get; set; }
    }
}
