using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Platform.Definitions
{
    public class LicenseVM: BaseVM
    {
        public string GModuleId { get; set; }

        public string GModuleName { get; set; }

        public string LicenseTypeId { get; set; }

        public string LicenseTypeName { get; set; }

        public string LicenseKey { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int RemainingUsageDays { get; set; }

        public int TotalCompanyNumber { get; set; }

        public int TotalUserNumber { get; set; }

        public bool UsingStatus { get; set; }

        public int Using { get; set; }

        public int CanUse { get; set; }
    }
}