using Platform.Application.VMs.Definitions.License;

namespace Platform.Application.VMs.Definitions.GModule
{
    public class LicenseOfTheCompanysModuleVM
    {
        public string GModuleName { get; set; }

        public int LicenseCount { get; set; }

        public List<LicenseWithLicenseDetailListVM> Licenses { get; set; }
    }
}
