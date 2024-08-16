using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.VMs.Definitions.LicenseType
{
    public class LicenseTypeVM : BaseVM
    {
        public string Name { get; set; }

        public int UsageMounth { get; set; }

        public int UserNumber { get; set; }

        public int CompanyNumber { get; set; }
    }
}
