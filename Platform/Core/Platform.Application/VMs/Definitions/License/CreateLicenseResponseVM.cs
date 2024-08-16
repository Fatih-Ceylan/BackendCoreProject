namespace Platform.Application.VMs.Definitions.License
{
    public class CreateLicenseResponseVM
    {
        public string Id { get; set; }

        public string CompanyId { get; set; }

        public string CompanyUrlPath { get; set; }

        public string GModuleId { get; set; }

        public string GModuleName { get; set; }

        public string LicenseTypeId { get; set; }

        public string LicenseKey { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int TotalCompanyNumber { get; set; }

        public int TotalUserNumber { get; set; }
    }
}