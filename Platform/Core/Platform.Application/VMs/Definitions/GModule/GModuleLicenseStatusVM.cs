using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Application.VMs.Definitions.GModule
{
    public class GModuleLicenseStatusVM : BaseVM
    {
        public string Name { get; set; }

        public string? LogoPath { get; set; }

        public bool IsThereLicense { get; set; }
    }
}